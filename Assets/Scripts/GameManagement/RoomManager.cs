using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : Singleton<RoomManager>
{
    Room currentRoom;
    List<Room> rooms;

    [Header("Entity Prefabs")]
    [SerializeField] List<Entity> entityPrefabs;
    Dictionary<string, Entity> ed = new Dictionary<string, Entity>();

    [Header("Stage Generation Settings")]
    [SerializeField, Range(1, 10)] int maxDepth;
    [SerializeField, Range(1, 4)] int maxDoors;

    // Generation variables
    List<Door> doorsToFill; // List of doors with no destination yet, generate a room for these doors

    // Components
    GridLayout gridLayout;

    void Start()
    {
        // Initialize variables
        rooms = new List<Room>();
        ed = new Dictionary<string, Entity>();
        for (int i = 0; i < entityPrefabs.Count; i++)
            ed.Add(entityPrefabs[i].name, entityPrefabs[i]);
        doorsToFill = new List<Door>();

        // Assign components
        gridLayout = GetComponent<GridLayout>();

        // Generate dungeon
        // Generate first room
        CreateRoom(0, null);
        // Iteratively generate layers
        GenerateLayer(1);

        // Enter first room
        EnterRoom(rooms[0]);
    }

    void GenerateLayer(int depth)
    {
        // Stop?
        if (depth > maxDepth || doorsToFill.Count <= 0) return;

        // Create new room for all empty doors
        List<Door> _doorsToFill = new List<Door>();
        for (int i = 0; i < doorsToFill.Count; i++)
            _doorsToFill.Add(doorsToFill[i]);
        doorsToFill.Clear();
        for (int i = 0; i < _doorsToFill.Count; i++)
            _doorsToFill[i].destination = CreateRoom(depth, _doorsToFill[i].GetComponent<Entity>().room);

        // Generate next layer
        GenerateLayer(depth + 1);
    }

    public void EnterRoom(Room nextRoom)
    {
        // Check if room exists
        if (nextRoom == null) return;

        // Exit current room
        currentRoom?.ExitRoom();

        // Enter next room
        currentRoom = nextRoom;
        currentRoom.EnterRoom();

        // Update grid
        gridLayout.ArrangeGrid();
    }

    public Room CreateRoom(int depth, Room parentRoom)
    {
        Room newRoom = new Room(depth, parentRoom);
        rooms.Add(newRoom);

        // If not starting room, spawn back door
        if (depth > 0)
        {
            Entity newDoor = SpawnedEntity(ed["back"].gameObject, newRoom);
            newRoom.roomEntities.Add(newDoor);
            newDoor.GetComponent<Door>().destination = parentRoom;
        }
        // Spawn doors according to depth
        for (int i = 0; i < maxDoors; i++)
        {
            if (Random.Range(0.0f, 1.0f) <= 1 - ((float)depth / (float)maxDepth))
            {
                Entity newDoor = SpawnedEntity(ed["door"].gameObject, newRoom);
                newRoom.roomEntities.Add(newDoor);
                doorsToFill.Add(newDoor.GetComponent<Door>());
            }
        }

        return newRoom;
    }

    Entity SpawnedEntity(GameObject entityToSpawn, Room room)
    {
        Entity _entity = Instantiate(entityToSpawn).GetComponent<Entity>();
        _entity.IsEnabled(false);
        _entity.room = room;
        return _entity;
    }
}

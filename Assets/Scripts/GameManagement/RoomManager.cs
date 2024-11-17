using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomManager : Singleton<RoomManager>
{
    Room currentRoom;
    [SerializeField] List<Room> rooms;

    // Room entities
    [SerializeField] List<Entity> entityPrefabs;

    // Components
    GridLayout gridLayout;

    void Start()
    {
        // Assign Components
        gridLayout = GetComponent<GridLayout>();

        CreateRoom(new List<int> { 0, 1, 1 });
        CreateRoom(new List<int> { 0, 1 });
        CreateRoom(new List<int> { 0, 2, 2, 2 });
    }

    private void Update()
    {
        if (Keyboard.current.digit0Key.wasPressedThisFrame)
            EnterRoom(0);
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            EnterRoom(1);
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            EnterRoom(2);
    }

    public void EnterRoom(int id)
    {
        // Check if room exists
        if (id > rooms.Count || rooms[id] == null) return;

        // Exit current room
        currentRoom?.ExitRoom();

        // Enter next room
        currentRoom = rooms[id];
        currentRoom.EnterRoom();

        // Update grid
        gridLayout.ArrangeGrid();
    }

    public void CreateRoom(List<int> entityIDs)
    {
        List<Entity> _entities = new List<Entity>();
        for (int i = 0; i < entityIDs.Count; i++)
            _entities.Add(entityPrefabs[entityIDs[i]]);
        CreateRoom(_entities);
    }

    public void CreateRoom(List<Entity> entities)
    {
        // Spawn entities to world and disable
        List<Entity> _entities = new List<Entity>();
        for (int i = 0; i < entities.Count; i++)
        {
            Entity _entity = Instantiate(entities[i].gameObject).GetComponent<Entity>();
            _entity.IsEnabled(false);
            _entities.Add(_entity);
        }
        // Create room
        rooms.Add(new Room(_entities));
    }
}

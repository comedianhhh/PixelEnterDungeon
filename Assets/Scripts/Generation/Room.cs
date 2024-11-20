using System;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public List<EC_Entity> roomEntities;
    public Room parentRoom;
    
    // Variables
    public int depth;
    public bool cleared;

    public Room(int depth, Room parentRoom)
    {
        roomEntities = new List<EC_Entity>();
        this.depth = depth;
        this.parentRoom = parentRoom;
        cleared = false;
    }

    public void EnterRoom()
    {
        for (int i = 0; i < roomEntities.Count; i++)
        {
            roomEntities[i].IsEnabled(true, DungeonManager.instance.transform);
        }

        CheckClear();
    }

    public void ExitRoom()
    {
        for (int i = 0; i < roomEntities.Count; i++)
        {
            roomEntities[i].IsEnabled(false);
        }
    }

    void SetAllDoors(bool _locked)
    {
        // Get all doors in room
        List<EC_Door> _doors = new List<EC_Door>();
        for (int i = 0; i < roomEntities.Count;i++)
        {
            if (roomEntities[i].GetComponent<EC_Door>())
                _doors.Add(roomEntities[i].GetComponent<EC_Door>());
        }
        // Set all doors
        for (int i = 0; i < _doors.Count;i++)
            _doors[i].SetLocked(_locked);
    }

    public void CheckClear()
    {
        // Already cleared
        if (cleared) return;
        cleared = true;

        // Check for hostiles
        for (int i = 0; i < roomEntities.Count; i++)
        {
            if (roomEntities[i].GetComponent<EC_Damage>())
                cleared = false;
        }

        if (cleared) SetAllDoors(false);
        else SetAllDoors(true);
    }
}

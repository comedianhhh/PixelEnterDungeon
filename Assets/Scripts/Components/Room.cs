using System;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public List<Entity> roomEntities;
    public Room parentRoom;

    // Variables
    public int depth;

    public Room(int depth, Room parentRoom)
    {
        roomEntities = new List<Entity>();
        this.depth = depth;
        this.parentRoom = parentRoom;
    }

    public void EnterRoom()
    {
        for (int i = 0; i < roomEntities.Count; i++)
        {
            roomEntities[i].IsEnabled(true, DungeonManager.instance.transform);
        }
    }

    public void ExitRoom()
    {
        for (int i = 0; i < roomEntities.Count; i++)
        {
            roomEntities[i].IsEnabled(false);
        }
    }
}

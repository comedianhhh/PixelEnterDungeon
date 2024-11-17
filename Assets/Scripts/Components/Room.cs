using System;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public List<Entity> roomEntities;

    // Variables
    public int depth;

    public Room(int depth)
    {
        this.depth = depth;
    }

    public void AddEntity(Entity entity)
    {
        roomEntities.Add(entity);
    }

    public void EnterRoom()
    {
        for (int i = 0; i < roomEntities.Count; i++)
        {
            roomEntities[i].IsEnabled(true, RoomManager.instance.transform);
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

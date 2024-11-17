using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room
{
    [SerializeField] List<Entity> entities;

    public Room(List<Entity> roomEntities)
    {
        entities = roomEntities;
    }

    public void EnterRoom()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].IsEnabled(true, RoomManager.instance.transform);
        }
    }

    public void ExitRoom()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].IsEnabled(false);
        }
    }
}

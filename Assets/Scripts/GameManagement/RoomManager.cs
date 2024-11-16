using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    Room currentRoom;
    List<Room> rooms;

    public void EnterRoom(int id)
    {
        // Check if room exists
        if (id > rooms.Count || rooms[id] == null) return;

        // Exit current room
        currentRoom.DisableRoom();

        // Enter next room
        currentRoom = rooms[id];
        currentRoom.EnableRoom();
    }
}

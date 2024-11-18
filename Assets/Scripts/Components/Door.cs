using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [HideInInspector] public Room destination;

    public void EnterRoom()
    {
        RoomManager.instance.EnterRoom(destination);
    }
}

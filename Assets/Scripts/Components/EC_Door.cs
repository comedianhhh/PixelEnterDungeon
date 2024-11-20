using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EC_Door : MonoBehaviour
{
    [HideInInspector] public Room destination;

    public void EnterRoom()
    {
        DungeonManager.instance.SwitchRoom(destination);
    }
}

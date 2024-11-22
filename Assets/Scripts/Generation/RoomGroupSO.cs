using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/Room Group", fileName = "New Room Group")]
public class RoomGroupSO : ScriptableObject
{
    public List<RoomSO> rooms = new List<RoomSO>();

    public RoomSO RandomRoom()
    {
        int rand = Random.Range(0, rooms.Count);
        return rooms[rand];
    }
}

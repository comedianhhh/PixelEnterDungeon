using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/Settings")]
public class GenerationSettingsSO : ScriptableObject
{
    [Header("Entity Prefabs")]
    public GameObject backDoorPrefab;
    public GameObject doorPrefab;
    public GameObject bossDoorPrefab;
    public GameObject bossKeyPrefab;
    public GameObject portalPrefab;

    [Header("Room Prefabs")]
    public List<StageGroup> rooms = new List<StageGroup>();

    [Header("Stage Generation Settings")]
    public int maxDepth = 3;
    public int maxDoors = 2;
    [Range(0.1f, 3f)] public float oddsPower = 1;

    [System.Serializable]
    public class RoomGroup
    {
        public string name;
        public List<RoomSO> rooms;
    }

    [System.Serializable]
    public class StageGroup
    {
        public string name;
        public List<RoomGroup> rooms;
        public List<RoomSO> bossRooms;

        public RoomSO RandomRoom(int depth)
        {
            return rooms[depth].rooms[Random.Range(0, rooms[depth].rooms.Count)];
        }

        public RoomSO RandomBossRoom()
        {
            return bossRooms[Random.Range(0, bossRooms.Count)];
        }
    }
}

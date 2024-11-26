using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonMapRenderer : MonoBehaviour
{
    [Header("Generation Settings")]
    [SerializeField] int mapWidth = 256;
    [SerializeField] int mapHeight = 256;
    [SerializeField] Color roomColor;
    [SerializeField] Color lineColor;
    [SerializeField] Color outlineColor;
    [SerializeField] Color bgColor;

    // Texture
    Texture2D mapTexture;

    // Generation
    Dictionary<int, List<DMR_RoomInfo>> roomsByDepth; // Key is int depth, returns list of rooms at that depth
    int maxDepth;

    // Components
    SpriteRenderer sr;

    class DMR_RoomInfo
    {
        public DMR_RoomInfo(int depth, Room.RoomType roomType)
        {
            this.depth = depth;
            this.roomType = roomType;
        }

        public int depth;
        public Vector2 position;
        public Room.RoomType roomType;
        public List<DMR_RoomInfo> children;
    }

    void Awake()
    {
        // Initialize variables
        roomsByDepth = new Dictionary<int, List<DMR_RoomInfo>>();

        // Initialize texure
        mapTexture = new Texture2D(mapWidth, mapHeight);
        mapTexture.filterMode = FilterMode.Point;
        mapTexture.wrapMode = TextureWrapMode.Clamp;

        // Set components
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(mapTexture, new Rect(0.0f, 0.0f, mapTexture.width, mapTexture.height), new Vector2(0.5f, 0.5f), 16);
    }

    public void DisplayMap(List<Room> mapRooms)
    {
        ClearMap();

        SortRooms(mapRooms);

        mapTexture.Apply();
    }

    void SortRooms(List<Room> mapRooms)
    {
        roomsByDepth = new Dictionary<int, List<DMR_RoomInfo>>();

        // Create and sort all rooms into roomsByDepth
        foreach (Room room in mapRooms)
        {
            DMR_RoomInfo roomInfo = new DMR_RoomInfo(room.depth, room.type);

            // Add to roomsByDepth
            if (!roomsByDepth.ContainsKey(room.depth))
            {
                roomsByDepth[room.depth] = new List<DMR_RoomInfo>();
            }
            roomsByDepth[room.depth].Add(roomInfo);

            // Assign children for the room
            roomInfo.children = new List<DMR_RoomInfo>();
            foreach (Room child in room.children)
            {
                // Find the child room corresponding DMR_RoomInfo
                DMR_RoomInfo childInfo = roomsByDepth.ContainsKey(child.depth) ? roomsByDepth[child.depth].FirstOrDefault(r => r.position == roomInfo.position) : null;
                
                if (childInfo != null)
                    roomInfo.children.Add(childInfo);
            }
        }

        // Find max depth
        maxDepth = roomsByDepth.Keys.Max();
    }

    void ClearMap()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                mapTexture.SetPixel(x, y, bgColor);
            }
        }
    }

    void DrawLine(Vector2 start, Vector2 end, Color color)
    {
        int steps = Mathf.CeilToInt(Vector2.Distance(start, end));
        for (int i = 0; i <= steps; i++)
        {
            // Interpolate the position
            Vector2 point = Vector2.Lerp(start, end, i / (float)steps);

            // Round to nearest integer pixel
            int x = Mathf.RoundToInt(point.x);
            int y = Mathf.RoundToInt(point.y);

            // Set the pixel if within bounds
            if (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight)
            {
                mapTexture.SetPixel(x, y, color);
            }
        }
    }
}

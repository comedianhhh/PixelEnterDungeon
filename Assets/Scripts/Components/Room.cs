using System.Collections.Generic;

public class Room
{
    List<Entity> entities;

    /// <summary>
    /// Disables all gameobject entities in room
    /// </summary>
    public void DisableRoom()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].Disable();
        }
    }

    /// <summary>
    /// Enables all gameobject entities in room
    /// </summary>
    public void EnableRoom()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].Enable();
        }
    }
}

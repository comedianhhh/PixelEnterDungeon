using UnityEngine;

public class Entity : Clickable
{
    [HideInInspector] public Room room;

    public void IsEnabled(bool enabled, Transform parent = null)
    {
        transform.parent = parent;
        gameObject.SetActive(enabled);
    }

    public void Remove()
    {
        room.roomEntities.Remove(this);
        IsEnabled(false);
        DungeonManager.instance.GetComponent<GridLayout>().ArrangeGrid();

        Destroy(gameObject);
    }
}

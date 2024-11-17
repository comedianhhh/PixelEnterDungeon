using UnityEngine;

public class Entity : Clickable
{
    [HideInInspector] public Room room;

    public void IsEnabled(bool enabled, Transform parent = null)
    {
        transform.parent = parent;
        gameObject.SetActive(enabled);
    }
}

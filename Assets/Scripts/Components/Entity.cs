using UnityEngine;

public class Entity : Clickable
{
    public void IsEnabled(bool enabled, Transform parent = null)
    {
        transform.parent = parent;
        gameObject.SetActive(enabled);
    }
}

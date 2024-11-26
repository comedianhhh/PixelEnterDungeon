using UnityEngine;
using UnityEngine.Events;

public class EC_Entity : Clickable
{
    [HideInInspector] public Room room;

    public UnityEvent removeEvent;

    public void IsEnabled(bool enabled, Transform parent = null)
    {
        transform.parent = parent;
        gameObject.SetActive(enabled);
    }

    public void Remove()
    {
        removeEvent.Invoke();

        room.roomEntities.Remove(this);
        IsEnabled(false);
        DungeonManager.instance.GetComponent<ArrangeGrid>().Arrange();

        Destroy(gameObject);
    }
}

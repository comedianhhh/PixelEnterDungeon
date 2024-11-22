using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent clickEvent;

    [Header("Tooltip")]
    public Sprite tooltip;

    public void Click()
    {
        clickEvent.Invoke();
    }
}

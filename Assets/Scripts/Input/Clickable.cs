using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent clickEvent;

    public void Click()
    {
        clickEvent.Invoke();
    }
}

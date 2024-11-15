using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent clickEvent;

    // Variables
    bool _wasPressed;
    public bool WasPressedThisFrame { get { return _wasPressed; } }

    public void Click()
    {
        clickEvent.Invoke();
        StartCoroutine(Clicked());
    }

    IEnumerator Clicked()
    {
        _wasPressed = true;
        yield return null;
        _wasPressed = false;
    }
}

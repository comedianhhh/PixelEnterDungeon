using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    // Variables
    Clickable _currentClickable;

    // Components
    Camera _camera;
    SpriteRenderer _tooltip;

    void Start()
    {
        _camera = Camera.main;
        _tooltip = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        _currentClickable = CurrentClickable();

        if (Mouse.current.leftButton.wasPressedThisFrame)
            _currentClickable?.Click();

        _tooltip.transform.position = MouseWorldPosition();
        _tooltip.sprite = _currentClickable?.tooltip;
    }

    Clickable CurrentClickable()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return null;

        Clickable clicked = rayHit.collider.GetComponent<Clickable>();

        return clicked;
    }

    public Vector2 MouseScreenPosition()
    {
        return Mouse.current.position.ReadValue();
    }

    public Vector2 MouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(MouseScreenPosition());
    }
}
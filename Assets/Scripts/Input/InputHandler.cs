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
        {
            // Clickable is an entity, check if enemy turn
            if (_currentClickable is EC_Entity && !TurnManager.instance.StateIs("Enemy"))
            {
                _currentClickable?.Click();
                TurnManager.instance.PlayerUsedAction = true;
            }
            // Click clickable
            else
                _currentClickable?.Click();
        }

        _tooltip.transform.position = MouseWorldPosition();
        _tooltip.sprite = _currentClickable?.tooltip;
    }

    Clickable CurrentClickable()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return null;

        Clickable clickable = rayHit.collider.GetComponent<Clickable>();

        return clickable;
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
using benjohnson;
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

        _tooltip.transform.position = MouseWorldPosition();
        _tooltip.sprite = _currentClickable?.tooltip;

        if (Mouse.current.leftButton.wasPressedThisFrame)
            HandleClick(_currentClickable);
    }

    void HandleClick(Clickable _clicked)
    {
        // No clickable
        if (_clicked == null)
            return;

        SoundManager.instance.PlaySound("Click");

        // Clickable is not entity, click
        if (!(_clicked is EC_Entity))
        {
            _clicked?.Click();
            return;
        }

        // Clickable is health entity, click and use player action
        if (_clicked.GetComponent<EC_Health>() && !TurnManager.instance.StateIs("Enemy"))
        {
            _clicked.Click();
            Player.instance.Damage.Damage(_clicked.GetComponent<EC_Health>());
            TurnManager.instance.PlayerUsedAction = true;
            return;
        }

        // Clickable is entity but not targetable, click, do not use player action
        if (_clicked is EC_Entity && !TurnManager.instance.StateIs("Enemy"))
        {
            _clicked.Click();
            return;
        }
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
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    Camera _camera;

    void Start()
    {
        SetCamera();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Click();
    }

    void SetCamera()
    {
        _camera = Camera.main;
    }

    void Click()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        Clickable clicked = rayHit.collider.GetComponent<Clickable>();
        clicked?.Click();
    }
}
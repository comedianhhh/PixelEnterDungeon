using UnityEngine;
using UnityEngine.InputSystem;

public class EC_Animator : MonoBehaviour
{
    // Variables
    Vector2 targetPosition;

    // Components
    Transform pt; // parent transform

    void Start()
    {
        // Set components
        pt = GetComponentInParent<EC_Entity>().transform;
    }

    void Update()
    {
        pt.localPosition = Vector2.Lerp(pt.localPosition, targetPosition, Time.deltaTime * 12);
    }

    public void SetTargetPosition(Vector2 pos, bool force = false)
    {
        targetPosition = pos;
        if (force)
            pt.localPosition = pos;
    }
}

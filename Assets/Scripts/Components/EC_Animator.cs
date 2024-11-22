using UnityEngine;
using UnityEngine.InputSystem;

public class EC_Animator : MonoBehaviour
{
    // Variables
    Vector2 targetPosition;
    Vector2 targetScale;

    // Components
    Transform pt; // parent transform
    SpriteRenderer sr;

    void Start()
    {
        // Set components
        pt = GetComponentInParent<EC_Entity>().transform;
        sr = GetComponent<SpriteRenderer>();

        // Initialize variables
        targetScale = Vector2.one;
    }

    void Update()
    {
        pt.localPosition = Vector2.Lerp(pt.localPosition, targetPosition, Time.deltaTime * 12);
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, Time.deltaTime * 12);
    }

    public void SetTargetPosition(Vector2 pos)
    {
        targetPosition = pos;
    }

    public void Squash(float x, float y)
    {
        transform.localScale = new Vector2(x, y);
    }
}

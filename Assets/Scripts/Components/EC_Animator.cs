using UnityEngine;
using UnityEngine.InputSystem;

public class EC_Animator : MonoBehaviour
{
    // Variables
    Vector2 targetPosition;
    Vector2 targetScale;

    // Sprites
    Sprite defaultSprite;
    Sprite backSprite;

    // Components
    SpriteRenderer sr;
    Transform pt; // parent transform

    void Start()
    {
        // Set components
        sr = GetComponent<SpriteRenderer>();
        pt = GetComponentInParent<EC_Entity>().transform;

        // Initialize variables
        targetScale = Vector2.one;
        defaultSprite = sr.sprite;
        backSprite = GameAssets.instance.GetSprite("card_back");
    }

    void Update()
    {
        pt.localPosition = Vector2.Lerp(pt.localPosition, targetPosition, Time.deltaTime * 12);
        transform.localScale = Vector2.MoveTowards(transform.localScale, targetScale, Time.deltaTime * 8);

        sr.sprite = transform.localScale.x >= 0 ? defaultSprite : backSprite;
        sr.sortingOrder = transform.localScale.x >= 0 ? -100 : 100;
    }

    public void SetTargetPosition(Vector2 pos, bool force = false)
    {
        targetPosition = pos;
        if (force)
            pt.localPosition = pos;
    }
}

using UnityEngine;

public class ScaleAnimator : MonoBehaviour
{
    [SerializeField] float lerpSpeed = 10f;

    // Variables
    Vector2 targetScale;

    void Start()
    {
        targetScale = Vector2.one;
    }

    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, lerpSpeed * Time.deltaTime);
    }

    public void SetScale(Vector2 scale)
    {
        transform.localScale = scale;
    }
}

using UnityEngine;

public class FloatingAnimator : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float height = 1.0f;

    // Variables
    float offset;
    float elapsed;
    Vector2 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
        elapsed += Random.Range(0.0f, 1.0f);
    }

    private void Update()
    {
        offset = Mathf.Sin(elapsed) * height;
        elapsed += Time.deltaTime * speed;

        transform.localPosition = new Vector2(0, offset) + originalPosition;
    }
}

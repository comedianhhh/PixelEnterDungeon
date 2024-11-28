using UnityEngine;

public class Key : MonoBehaviour
{
    Vector2 targetPosition = new Vector2(-16f, -4.75f);
    [SerializeField] float lerpSpeed = 1;

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
    }
}

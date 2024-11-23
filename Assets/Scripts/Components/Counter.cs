using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] List<Sprite> smallCharacters = new List<Sprite>();
    [SerializeField] List<Sprite> largeCharacters = new List<Sprite>();
    [SerializeField] bool largeText;
    [SerializeField] GameObject numberPrefab;
    [SerializeField] float spacing;

    public void SetText(string text, int color = 0)
    {
        // Clear numbers
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        // Create new numbers
        for (int i = 0; i < text.Length; i++)
        {
            GameObject _go = Instantiate(numberPrefab, transform);
            _go.transform.localPosition = new Vector3(largeText ? i * 7f/17f : i * 0.25f, 0, 0);
            _go.GetComponent<SpriteRenderer>().sprite = largeText ? largeCharacters[color * 10 + text[i] - 48] : smallCharacters[color * 10 + text[i] - 48];
        }
    }
}

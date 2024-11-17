using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] List<Sprite> characters = new List<Sprite>();
    [SerializeField] GameObject numberPrefab;
    [SerializeField] float spacing = 1.0f;

    public void SetText(string text, Color color)
    {
        // Clear numbers
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        // Create new numbers
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            GameObject number = Instantiate(numberPrefab, transform);
            number.transform.localPosition = new Vector3(i * spacing, 0, 0);
            SpriteRenderer sr = number.GetComponent<SpriteRenderer>();
            sr.sprite = CharToSprite(c);
            sr.color = color;
        }
    }

    private Sprite CharToSprite(char c)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name[0] == c)
                return characters[i];
        }
        return null;
    }
}

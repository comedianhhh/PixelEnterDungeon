using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] List<Sprite> characters = new List<Sprite>();
    [SerializeField] GameObject numberPrefab;
    [SerializeField] float spacing = 1.0f;

    public void SetText(string text, int color = 0)
    {
        // Clear numbers
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        // Create new numbers
        for (int i = 0; i < text.Length; i++)
        {
            string str = "numbers_" + (text[i] - 48 + (color * 10)).ToString();

            GameObject number = Instantiate(numberPrefab, transform);
            number.transform.localPosition = new Vector3(i * spacing, 0, 0);
            number.GetComponent<SpriteRenderer>().sprite = CharToSprite(str);
        }
    }

    private Sprite CharToSprite(string str)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == str)
                return characters[i];
        }
        return null;
    }
}

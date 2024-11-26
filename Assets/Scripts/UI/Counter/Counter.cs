using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] CounterNumberSet numbers;
    [SerializeField] GameObject numberPrefab;
    [SerializeField] int orderInLayer;

    public void SetText(string text, int color = 0)
    {
        // Clear numbers
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        // Create new numbers
        for (int i = 0; i < text.Length; i++)
        {
            GameObject _go = Instantiate(numberPrefab, transform);
            _go.transform.localPosition = new Vector3(i * numbers.spacing, 0, 0);
            _go.GetComponent<SpriteRenderer>().sprite = numbers.numbers[color * 10 + text[i] - 48];
            _go.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
        }
    }
}

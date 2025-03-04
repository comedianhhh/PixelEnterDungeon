using UnityEngine;

public class ArrangeGrid : MonoBehaviour
{
    public int maxColumns = 3;
    public Vector2 spacing = new Vector2(1.0f, 1.0f);
    public Vector2 offset = Vector2.zero;

    public void Arrange(bool _force = false)
    {
        int childCount = transform.childCount;

        // # of rows
        int rows = Mathf.CeilToInt((float)childCount / maxColumns);

        // Total grid height
        float gridHeight = (rows - 1) * spacing.y;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            int row = i / maxColumns;
            int column = i % maxColumns;

            // # of elements in current row
            int itemsInRow = Mathf.Min(maxColumns, childCount - row * maxColumns);

            // Width of the current row
            float rowWidth = (itemsInRow - 1) * spacing.x;

            // Centering offsets
            Vector2 centerOffset = new Vector2(rowWidth / 2, gridHeight / 2);

            // Set the new position for the child
            Vector2 newPosition = new Vector2(
                column * spacing.x - centerOffset.x + offset.x,
                -row * spacing.y + centerOffset.y + offset.y
            );
            if (child.GetComponentInChildren<EC_Animator>())
                child.GetComponentInChildren<EC_Animator>().SetTargetPosition(newPosition);
            else
                child.position = newPosition;
            if (_force) child.transform.localPosition = newPosition;
        }
    }
}

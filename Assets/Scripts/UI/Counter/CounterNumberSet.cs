using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/Counter/Number Set", fileName = "New Number Set")]
public class CounterNumberSet : ScriptableObject
{
    public List<Sprite> numbers = new List<Sprite>();
    public float spacing;
}

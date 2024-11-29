using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/Room", fileName = "New Room")]
public class RoomSO : ScriptableObject
{
    public List<GameObject> entities = new List<GameObject>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EC_Damage : MonoBehaviour
{
    public int damage;

    // Components
    [SerializeField] Counter counter;

    void Start()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        if (counter == null) return;
        counter.SetText(damage.ToString(), 1);
    }
}

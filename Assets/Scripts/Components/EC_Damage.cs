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

    public void Attack()
    {
        GetComponentInChildren<EC_Animator>()?.Squash(1.5f, 1.5f);
        Player.instance.Health.Damage(damage);
    }

    void UpdateCounter()
    {
        if (counter == null) return;
        counter.SetText(damage.ToString(), 1);
    }
}

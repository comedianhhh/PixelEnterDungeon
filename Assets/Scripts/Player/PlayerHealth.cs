using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;

    // Components
    [SerializeField] Counter cCounter;
    [SerializeField] Counter mCounter;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateCurrent();
        UpdateMax();
    }

    public void Damage(int value)
    {
        ArtifactManager.instance.TriggerTakeDamage();
        SoundManager.instance.PlaySound("Player Hurt");
        DamagePopup.CreatePopup(transform.position, value);
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Kill();
        }
        UpdateCurrent();
    }

    public void IncreaseHealth(int increase)
    {
        maxHealth += increase;
        currentHealth += increase;
        if (maxHealth < 0)
            maxHealth = 0;
        if (currentHealth < 0)
            currentHealth = 0;
        UpdateCurrent();
        UpdateMax();
    }

    public void Heal(int value)
    {
        currentHealth += value;
        if (currentHealth < 0)
            currentHealth = 0;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        UpdateCurrent();
    }

    void UpdateCurrent()
    {
        if (cCounter == null) return;
        cCounter.SetText(currentHealth.ToString(), 0);
    }

    void UpdateMax()
    {
        if (mCounter == null) return;
        mCounter.SetText(maxHealth.ToString(), 0);
    }

    public void Kill()
    {
        Debug.Log("PLAYER KILLED");
    }
}

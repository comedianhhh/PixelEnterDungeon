using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;

    // Components
    [SerializeField] Counter counter;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateCounter();
    }

    public void Damage(int value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UpdateCounter();
            Kill();
        }
    }

    public void Heal(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            UpdateCounter();
        }
    }

    void UpdateCounter()
    {
        counter.SetText("h" + currentHealth.ToString(), Color.red);
    }

    public void Kill()
    {

    }
}

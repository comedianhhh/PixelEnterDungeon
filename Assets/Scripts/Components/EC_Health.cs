using UnityEngine;
using UnityEngine.Events;

public class EC_Health : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;


    [Header("Events")]
    public UnityEvent deathEvent;
    public UnityEvent damageEvent;

    // Components
    EC_Animator anim;
    [SerializeField] Counter counter;

    void Start()
    {
        anim = GetComponentInChildren<EC_Animator>();

        currentHealth = maxHealth;
        UpdateCounter();
    }

    public void Damage(int value)
    {
        damageEvent.Invoke();
        ArtifactManager.instance.TriggerDealDamage();
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Kill();
        }
        UpdateCounter();
        anim?.Squash(1.5f, 0.75f);
    }

    public void Heal(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateCounter();
    }

    void UpdateCounter()
    {
        if (counter == null) return;
        counter.SetText(currentHealth.ToString(), 0);
    }

    public void Kill()
    {
        deathEvent.Invoke();

        GetComponent<EC_Entity>().Remove();
    }
}

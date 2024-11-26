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

    [Header("FX")]
    public GameObject deathFX;

    void Start()
    {
        anim = GetComponentInChildren<EC_Animator>();

        currentHealth = maxHealth;
        UpdateCounter();
    }

    public void Damage(int value)
    {
        damageEvent.Invoke();
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

        if (deathFX != null)
        {
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            Destroy(fx, 2);
        }

        GetComponent<EC_Entity>().Remove();
    }
}

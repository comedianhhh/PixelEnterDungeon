using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int money;

    // Components
    [SerializeField] Counter counter;

    void Start()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        if (counter == null) return;
        counter.SetText(money.ToString(), 3);
    }
}

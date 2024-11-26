using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int money;

    // Components
    [SerializeField] Counter counter;
    ScaleAnimator anim;

    void Start()
    {
        anim = counter.transform.parent.GetComponent<ScaleAnimator>();
        UpdateCounter();
    }

    void UpdateCounter()
    {
        if (counter == null) return;
        counter.SetText(money.ToString(), 3);
    }

    public void AddMoney(int value)
    {
        money += value;
        UpdateCounter();
        anim.SetScale(new Vector2(1.5f, 1.5f));
    }
}

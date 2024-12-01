using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Apple")]
public class A_Apple : A_Base
{
    public int healthIncrease;

    public override void OnPickup()
    {
        triggered = true;
    }

    public override void Trigger()
    {
        Player.instance.Health.IncreaseHealth(healthIncrease);
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Dying Heart")]
public class A_DyingHeart : A_Base
{
    public int loseAmount;

    public int hpGain;

    public int damageGain;

    public override void OnEnterRoom()
    {
        triggered = true;

        Player.instance.Health.IncreaseHealth(-loseAmount);
    }
    
    public override void OnPickup()
    {
        triggered = true;

        Player.instance.Health.IncreaseHealth(hpGain);
        Player.instance.Damage.IncreaseDamage(damageGain);
    }
}

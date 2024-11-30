using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Vengeful Ring")]
public class A_VengefulRing : A_Base
{
    public int damageIncrease;
    public int healthDecrease;

    public override void OnPickup()
    {
        Player.instance.Damage.IncreaseDamage(damageIncrease);
        Player.instance.Health.IncreaseHealth(-healthDecrease);
    }
}

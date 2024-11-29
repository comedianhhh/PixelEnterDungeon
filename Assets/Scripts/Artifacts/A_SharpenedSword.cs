using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Sharpened Sword")]
public class A_SharpenedSword : A_Base
{
    public int damageIncrease;

    public override void OnPickup()
    {
        triggered = true;

        Player.instance.Damage.IncreaseDamage(damageIncrease);
    }
}

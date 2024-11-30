using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Kings Mug")]
public class A_KingsMug : A_Base
{
    public int damageIncrease;

    public override void OnEnterBossRoom()
    {
        triggered = true;

        Player.instance.Damage.IncreaseDamage(damageIncrease);
    }
}

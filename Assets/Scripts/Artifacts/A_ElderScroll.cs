using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Elder Scroll")]
public class A_ElderScroll : A_Base
{
    public int bossDamageIncrease;

    public override void OnEnterBossRoom()
    {
        triggered = true;

        Player.instance.Damage.IncreaseDamage(bossDamageIncrease);
    }

    public override void OnBossDefeated()
    {
        triggered = true;

        Player.instance.Damage.IncreaseDamage(-bossDamageIncrease);
    }
}

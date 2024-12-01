using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Elder Scroll")]
public class A_ElderScroll : A_Base
{
    public int bossDamageIncrease;
    bool enter = false;

    public override void OnEnterBossRoom()
    {
        triggered = true;
        enter = true;
    }

    public override void OnBossDefeated()
    {
        triggered = true;
        enter = false;
    }

    public override void Trigger()
    {
        if (enter)
            Player.instance.Damage.IncreaseDamage(bossDamageIncrease);
        else
            Player.instance.Damage.IncreaseDamage(-bossDamageIncrease);
    }
}

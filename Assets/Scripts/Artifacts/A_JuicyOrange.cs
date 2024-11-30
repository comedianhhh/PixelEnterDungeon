using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Juicy Orange")]
public class A_JuicyOrange : A_Base
{
    public override void OnPickup()
    {
        triggered = true;

        Player.instance.Health.Heal(999);
    }

    public override void OnBossDefeated()
    {
        triggered = true;

        Player.instance.Health.Heal(999);
    }
}

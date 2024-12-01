using benjohnson;
using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Vampire Fang")]
public class A_VampireFang : A_Base
{
    public int healAmount;

    public override void OnKillEnemy()
    {
        triggered = true;
    }

    public override void Trigger()
    {
        Player.instance.Health.Heal(healAmount);
    }
}

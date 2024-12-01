using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Shiny Egg")]
public class A_ShinyEgg : A_Base
{
    public int healAmount;

    public override void OnTakeDamage()
    {
        triggered = true;
    }

    public override void Trigger()
    {
        Player.instance.Health.Heal(healAmount);
    }
}

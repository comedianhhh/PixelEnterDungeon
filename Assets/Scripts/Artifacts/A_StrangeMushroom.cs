using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Strange Mushroom")]
public class A_StrangeMushroom : A_Base
{
    public int healAmount;

    public override void OnClearRoom()
    {
        triggered = true;
    }

    public override void Trigger()
    {
        Player.instance.Health.Heal(healAmount);
    }
}

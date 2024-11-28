using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Strange Mushroom")]
public class A_StrangeMushroom : A_Base
{
    public int healAmount;

    public override void OnClearRoom()
    {
        triggered = true;

        Player.instance.Health.Heal(healAmount);
    }
}

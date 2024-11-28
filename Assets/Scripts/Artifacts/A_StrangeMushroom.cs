using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Strange Mushroom")]
public class A_StrangeMushroom : A_Base
{
    public int healAmount;

    public override void OnClearRoom()
    {
        Player.instance.Health.Heal(healAmount);
    }
}

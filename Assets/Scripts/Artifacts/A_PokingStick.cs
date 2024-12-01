using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Poking Stick")]
public class A_PokingStick : A_Base
{
    public int coins;

    public override void OnDealDamage()
    {
        triggered = true;
    }

    public override void Trigger()
    {
        Player.instance.Wallet.AddMoney(coins);
    }
}

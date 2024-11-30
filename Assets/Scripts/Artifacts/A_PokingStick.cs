using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Poking Stick")]
public class A_PokingStick : A_Base
{
    public int coins;

    public override void OnDealDamage()
    {
        Player.instance.Wallet.AddMoney(coins);
    }
}

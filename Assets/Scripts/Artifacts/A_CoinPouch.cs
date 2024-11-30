using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Coin Pouch")]
public class A_CoinPouch : A_Base
{
    public int coins;

    public override void OnPickup()
    {
        triggered = true;

        Player.instance.Wallet.AddMoney(coins, coins);
        Player.instance.Wallet.extraCoins = -9999;
    }
}

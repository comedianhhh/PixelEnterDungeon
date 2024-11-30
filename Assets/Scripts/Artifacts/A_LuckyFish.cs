using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Lucky Fish")]
public class A_LuckyFish : A_Base
{
    public override void OnPickup()
    {
        triggered = true;

        Player.instance.Wallet.extraCoins++;
    }
}

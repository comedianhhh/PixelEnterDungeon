using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Lucky Fish")]
public class A_LuckyFish : A_Base
{
    public override void OnPickup()
    {
        triggered = true;
    }

    public override void Trigger()
    {
        Player.instance.Wallet.extraCoins++;
    }
}

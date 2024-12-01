using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Spiky Rock")]
public class A_SpikyRock : A_Base
{
    public int damage;

    public override void OnTakeDamage()
    {
        List<EC_Damage> hostiles = DungeonManager.instance.CurrentRoom.GetHostiles();
        if (hostiles.Count > 0)
            triggered = true;
    }

    public override void Trigger()
    {
        List<EC_Damage> hostiles = DungeonManager.instance.CurrentRoom.GetHostiles();
        if (hostiles.Count > 0)
            hostiles[Random.Range(0, hostiles.Count)]?.GetComponent<EC_Health>().Damage(damage);
    }
}

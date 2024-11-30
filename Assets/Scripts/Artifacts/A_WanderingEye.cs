using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Wandering Eye")]
public class A_WanderingEye : A_Base
{
    public int damage;

    public override void OnStartOfEnemyTurn()
    {
        List<EC_Damage> hostiles = DungeonManager.instance.CurrentRoom.GetHostiles();
        if (hostiles.Count > 0)
        {
            triggered = true;

            foreach (EC_Damage hostile in hostiles)
                hostile.GetComponent<EC_Health>().Damage(damage);
        }
    }
}

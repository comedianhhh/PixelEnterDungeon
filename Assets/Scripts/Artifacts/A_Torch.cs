using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Torch")]
public class A_Torch : A_Base
{
    public int damage;

    public override void OnEnterRoom()
    {
        List<EC_Damage> hostiles = DungeonManager.instance.CurrentRoom.GetHostiles();
        if (hostiles.Count > 0)
            triggered = true;
    }

    public override void Trigger()
    {
        List<EC_Damage> hostiles = DungeonManager.instance.CurrentRoom.GetHostiles();
        if (hostiles.Count > 0)
        {
            foreach (EC_Damage hostile in hostiles)
                hostile.GetComponent<EC_Health>().Damage(damage);
        }
    }
}

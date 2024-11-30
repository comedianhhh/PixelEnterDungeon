using benjohnson;
using UnityEngine;

[CreateAssetMenu(menuName = "Artifacts/Hot Pepper")]
public class A_HotPepper : A_Base
{
    [Range(0f, 1f)] public float probability;

    public int damageIncrease;

    public override void OnKillEnemy()
    {
        bool passed = Utilities.TestProbability(probability);
        if (passed)
        {
            triggered = true;

            Player.instance.Damage.IncreaseDamage(damageIncrease);
        }
    }
}

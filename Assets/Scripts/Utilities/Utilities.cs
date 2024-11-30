using UnityEngine;

namespace benjohnson
{
    public static class Utilities
    {
        public static bool TestProbability(float probability)
        {
            probability = Mathf.Clamp01(probability);

            float randomValue = Random.value;

            return randomValue < probability;
        }
    }
}

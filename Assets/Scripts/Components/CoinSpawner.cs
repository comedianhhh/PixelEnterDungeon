using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public void CreateCoins(int count)
    {
        StartCoroutine(SpawnCoins(count));
    }

    private IEnumerator SpawnCoins(int numberOfCoins)
    {
        int count = 0;
        while (count < numberOfCoins)
        {
            Instantiate(GameAssets.instance.GetGameObject("coin"), Vector2.zero, Quaternion.identity);
            count++;
            yield return new WaitForSeconds(0.025f);
        }
    }
}

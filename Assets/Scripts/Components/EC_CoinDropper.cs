using UnityEngine;

public class EC_CoinDropper : MonoBehaviour
{
    public int amount;
    public int rand;
    public GameObject coinPrefab;

    public void DropCoins()
    {
        int coins = amount + Random.Range(-rand, rand + 1);
        for (int i = 0; i < coins; i++)
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}

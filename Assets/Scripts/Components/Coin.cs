using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float startSpeed = 1;
    [SerializeField] float pickupY = -12;

    // Components
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-startSpeed, startSpeed), Random.Range(startSpeed * 0.75f, startSpeed * 1.25f));
    }

    void Update()
    {
        if (transform.position.y <= pickupY)
        {
            // Pick up
            Player.instance.Wallet.AddMoney(1);
            Destroy(gameObject);
        }
    }
}

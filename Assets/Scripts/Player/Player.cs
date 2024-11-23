using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    // Components
    public PlayerHealth Health { get { return _health; } }
    PlayerHealth _health;
    public PlayerDamage Damage { get { return _damage; } }
    PlayerDamage _damage;
    public PlayerWallet Wallet { get { return _wallet; } }
    PlayerWallet _wallet;

    void Start()
    {
        _health = GetComponent<PlayerHealth>();
        _damage = GetComponent<PlayerDamage>();
        _wallet = GetComponent<PlayerWallet>();
    }
}

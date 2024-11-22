using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    // Components
    public PlayerHealth Health { get { return _health; } }
    PlayerHealth _health;

    void Start()
    {
        _health = GetComponent<PlayerHealth>();
    }
}

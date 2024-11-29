using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class A_Base : ScriptableObject
{
    public Sprite sprite;
    public Sprite tooltip;

    // Variables
    [HideInInspector] public bool triggered = false;

    public virtual void OnStartOfTurn() { }
    public virtual void OnEndOfTurn() { }
    public virtual void OnEnterRoom() { }
    public virtual void OnEnterBossRoom() { }
    public virtual void OnClearRoom() { }
    public virtual void OnTakeDamage() { }
    public virtual void OnDealDamage() { }
    public virtual void OnKillEnemy() { }
    public virtual void OnPickup() { }
}

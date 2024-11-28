using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class A_Base : ScriptableObject
{
    public string a_name;
    public Sprite sprite;
    [TextArea] public string description;

    public virtual void OnStartOfTurn() { }
    public virtual void OnEndOfTurn() { }
    public virtual void OnEnterRoom() { }
    public virtual void OnEnterBossRoom() { }
    public virtual void OnClearRoom() { }
    public virtual void OnTakeDamage() { }
    public virtual void OnDealDamage() { }
    public virtual void OnPickup() { }
}

using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : Singleton<ArtifactManager>
{
    List<A_Base> artifacts;

    public void TriggerStartOfTurn()
    {
        Debug.Log("TriggerStartOfTurn");
    }

    public void TriggerEndOfTurn()
    {
        Debug.Log("TriggerEndOfTurn");
    }

    public void TriggerEnterRoom()
    {
        Debug.Log("TriggerEnterRoom");
    }

    public void TriggerEnterBossRoom()
    {
        Debug.Log("TriggerEnterBossRoom");
    }

    public void TriggerClearRoom()
    {
        Debug.Log("TriggerClearRoom");
    }

    public void TriggerTakeDamage()
    {
        Debug.Log("TriggerTakeDamage");
    }

    public void TriggerDealDamage()
    {
        Debug.Log("TriggerDealDamage");
    }

    public void TriggerPickup()
    {
        Debug.Log("TriggerPickup");
    }
}

using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : Singleton<ArtifactManager>
{
    List<A_Base> artifacts;

    private void Start()
    {
        artifacts = new List<A_Base>();
    }

    public void AddArtifact(A_Base artifact)
    {
        artifacts.Add(artifact);
        artifact.OnPickup();
    }

    public void TriggerStartOfTurn()
    {
        foreach (A_Base artifact in artifacts)
        {
            artifact.OnStartOfTurn();
        }
    }

    public void TriggerEndOfTurn()
    {
        foreach (A_Base artifact in artifacts)
        {
            artifact.OnEndOfTurn();
        }
    }

    public void TriggerEnterRoom()
    {
        foreach (A_Base artifact in artifacts)
        {
            artifact.OnEnterRoom();
        }
    }

    public void TriggerEnterBossRoom()
    {
        foreach (A_Base artifact in artifacts)
        {
            artifact.OnEnterBossRoom();
        }
    }

    public void TriggerClearRoom()
    {
        foreach (A_Base artifact in artifacts)
        {
            artifact.OnClearRoom();
        }
    }

    public void TriggerTakeDamage()
    {
        foreach (A_Base artifact in artifacts)
        {
            artifact.OnTakeDamage();
        }
    }

    public void TriggerDealDamage()
    {
        foreach (A_Base artifact in artifacts)
        {
            artifact.OnDealDamage();
        }
    }
}

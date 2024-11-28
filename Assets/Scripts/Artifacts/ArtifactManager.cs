using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : Singleton<ArtifactManager>
{
    List<Artifact> artifacts;

    [Header("Components")]
    [SerializeField] GameObject visualizerGO;

    protected override void Awake()
    {
        base.Awake();

        artifacts = new List<Artifact>();
    }

    public void AddArtifact(A_Base artifact)
    {
        artifacts.Add(new Artifact(artifact, Instantiate(visualizerGO, transform.position + new Vector3(artifacts.Count * 2.5f, 0), Quaternion.identity, transform).GetComponent<ArtifactVisualizer>()));

        // Trigger pickup
        artifact.OnPickup();
    }

    class Artifact
    {
        public A_Base artifact;
        public ArtifactVisualizer visualizer;

        public Artifact(A_Base artifact, ArtifactVisualizer visualizer)
        {
            this.artifact = artifact;
            this.visualizer = visualizer;
            visualizer.Visualize(artifact);
        }

        public void TryTrigger()
        {
            if (artifact.triggered)
            {
                artifact.triggered = false;
                visualizer.Trigger();
            }
        }
    }

    #region Triggers

    public void TriggerStartOfTurn()
    {
        foreach (Artifact artifact in artifacts)
        {
            artifact.artifact.OnStartOfTurn();
            artifact.TryTrigger();
        }
    }

    public void TriggerEndOfTurn()
    {
        foreach (Artifact artifact in artifacts)
        {
            artifact.artifact.OnEndOfTurn();
            artifact.TryTrigger();
        }
    }

    public void TriggerEnterRoom()
    {
        foreach (Artifact artifact in artifacts)
        {
            artifact.artifact.OnEnterRoom();
            artifact.TryTrigger();
        }
    }

    public void TriggerEnterBossRoom()
    {
        foreach (Artifact artifact in artifacts)
        {
            artifact.artifact.OnEnterBossRoom();
            artifact.TryTrigger();
        }
    }

    public void TriggerClearRoom()
    {
        foreach (Artifact artifact in artifacts)
        {
            artifact.artifact.OnClearRoom();
            artifact.TryTrigger();
        }
    }

    public void TriggerTakeDamage()
    {
        foreach (Artifact artifact in artifacts)
        {
            artifact.artifact.OnTakeDamage();
            artifact.TryTrigger();
        }
    }

    public void TriggerDealDamage()
    {
        foreach (Artifact artifact in artifacts)
        {
            artifact.artifact.OnDealDamage();
            artifact.TryTrigger();
        }
    }

    #endregion
}

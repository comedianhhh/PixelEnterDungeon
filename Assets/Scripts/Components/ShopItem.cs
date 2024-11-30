using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : ArtifactVisualizer
{
    [SerializeField] Counter costCounter;

    public override void Visualize(A_Base artifact)
    {
        base.Visualize(artifact);

        costCounter.SetText(artifact.cost.ToString(), 3);
    }

    public void Buy()
    {
        ArtifactManager.instance.AddArtifact(artifact);

        Destroy(gameObject);
    }
}

using UnityEngine;

public class ArtifactVisualizer : MonoBehaviour
{
    A_Base artifact;

    // Components
    SpriteRenderer sr;
    ScaleAnimator anim;
    Clickable click;
    ParticleSystem ps;

    public void Visualize(A_Base artifact)
    {
        // Set components
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = artifact.sprite;
        anim = GetComponentInChildren<ScaleAnimator>();
        click = GetComponent<Clickable>();
        click.tooltip = artifact.tooltip;
        ps = GetComponentInChildren<ParticleSystem>();

        this.artifact = artifact;
    }

    public void Trigger()
    {
        anim.SetScale(new Vector2(3.0f, 3.0f));
    }
}

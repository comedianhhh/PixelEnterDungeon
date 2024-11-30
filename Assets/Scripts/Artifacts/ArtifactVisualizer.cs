using UnityEngine;

public class ArtifactVisualizer : MonoBehaviour
{
    [HideInInspector] public A_Base artifact;

    // Components
    SpriteRenderer sr;
    ScaleAnimator anim;
    Clickable click;

    public virtual void Visualize(A_Base artifact)
    {
        this.artifact = artifact;

        // Set components
        anim = GetComponentInChildren<ScaleAnimator>();
        sr = anim.GetComponent<SpriteRenderer>();
        sr.sprite = artifact.sprite;
        click = GetComponent<Clickable>();
        click.tooltip = artifact.tooltip;
    }

    public void Trigger()
    {
        anim.SetScale(new Vector2(3.0f, 3.0f));
    }
}

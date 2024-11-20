using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EC_Door : MonoBehaviour
{
    [HideInInspector] public Room destination;

    [Header("Icons")]
    [SerializeField] SpriteRenderer iconSR;
    [SerializeField] Sprite openSprite;
    [SerializeField] Sprite lockedSprite;

    // Variables
    bool locked;

    public void SetLocked(bool _locked)
    {
        if (locked && !_locked)
        {
            // unlocked FX
        }
        if (!locked && _locked)
        {
            // locked FX
        }

        locked = _locked;

        iconSR.sprite = locked ? lockedSprite : openSprite;
    }

    public void EnterRoom()
    {
        if (locked) return;

        DungeonManager.instance.SwitchRoom(destination);
    }
}

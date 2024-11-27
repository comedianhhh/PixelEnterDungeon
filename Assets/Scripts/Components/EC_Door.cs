using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EC_Door : MonoBehaviour
{
    [HideInInspector] public Room destination;

    [SerializeField] bool requiresKey;
    bool keyFound;

    [Header("Icons")]
    [SerializeField] SpriteRenderer iconSR;
    [SerializeField] Sprite openSprite;
    [SerializeField] Sprite lockedSprite;
    [SerializeField] Sprite openTooltip;
    [SerializeField] Sprite lockedTooltip;

    // Variables
    bool locked;

    // Components
    EC_Entity entity;

    void Awake()
    {
        entity = GetComponent<EC_Entity>();
        keyFound = false;
    }

    public virtual void SetLocked(bool _locked, bool key = false)
    {
        if (requiresKey && key)
            keyFound = true;

        if (_locked)
        {
            Lock();
            return;
        }

        if (requiresKey && keyFound)
        {
            Unlock();
        }
        else if (!requiresKey)
        {
            Unlock();
        }
        else
        {
            Lock();
        }
    }

    void Unlock()
    {
        locked = false;
        iconSR.sprite = openSprite;
        entity.tooltip = openTooltip;
    }

    void Lock()
    {
        locked = true;
        iconSR.sprite = lockedSprite;
        entity.tooltip = lockedTooltip;
    }

    public void EnterRoom()
    {
        if (locked) return;

        DungeonManager.instance.SwitchRoom(destination);
    }
}

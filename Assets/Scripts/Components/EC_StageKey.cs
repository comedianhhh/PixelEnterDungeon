using UnityEngine;

public class EC_StageKey : MonoBehaviour
{
    [HideInInspector] public EC_Door keyDoor;

    public void UnlockKeyDoor()
    {
        keyDoor.SetLocked(false, true);
    }
}

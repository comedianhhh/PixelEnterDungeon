using UnityEngine;

public class EC_StageKey : MonoBehaviour
{
    [HideInInspector] public EC_Door keyDoor;

    [SerializeField] GameObject keyObject;

    public void UnlockKeyDoor()
    {
        keyDoor.SetLocked(false, true);
        Instantiate(keyObject, transform.position, Quaternion.identity);
    }
}

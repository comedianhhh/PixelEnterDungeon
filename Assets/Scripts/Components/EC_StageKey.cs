using UnityEngine;

public class EC_StageKey : MonoBehaviour
{
    [HideInInspector] public EC_Door keyDoor;

    [SerializeField] GameObject keyObject;

    public void UnlockKeyDoor()
    {
        keyDoor.SetLocked(false, true);
        GameObject keyGO = Instantiate(keyObject, transform.position, Quaternion.identity);
        keyGO.transform.parent = transform;
        keyGO.transform.parent = null;
    }
}

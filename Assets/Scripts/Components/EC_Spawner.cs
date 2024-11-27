using UnityEngine;

public class EC_Spawner : MonoBehaviour
{
    public EC_Entity entity;

    public void Spawn()
    {
        EC_Entity _entity = DungeonManager.instance.SpawnEntity(entity, DungeonManager.instance.CurrentRoom);
        _entity.IsEnabled(true);
    }
}

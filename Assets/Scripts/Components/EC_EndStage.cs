using UnityEngine;
using UnityEngine.SceneManagement;

public class EC_EndStage : MonoBehaviour
{
    public void NextStage()
    {
        DungeonManager.instance.GenerateDungeon(0);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class EC_EndStage : MonoBehaviour
{
    public void NextStage()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}

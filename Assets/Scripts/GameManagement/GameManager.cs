using benjohnson;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Components")]
    public TurnManager turnManager;

    [HideInInspector] public int stage = 0;

    void Start()
    {
        // Load player
        SceneManager.instance.LoadScene(2);

        LoadNextStage(false);
    }

    public void DungeonLoaded()
    {
        // Start game
        turnManager.StartTurnManager();
    }

    public void LoadNextStage(bool unload = true)
    {
        // Stop the game
        turnManager.StopTurnManager();

        //stage++;

        // Reload dungeon
        if (unload)
            SceneManager.instance.UnloadScene(3);
        SceneManager.instance.LoadScene(3);
    }
}

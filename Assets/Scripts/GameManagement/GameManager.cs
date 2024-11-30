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

        LoadNextStage();
    }

    public void DungeonLoaded()
    {
        // Start game
        turnManager.StartTurnManager();
    }

    public void LoadShop()
    {
        // Stop the game
        turnManager.StopTurnManager();

        // Unload dungeon
        SceneManager.instance.UnloadScene(3);

        // Load shop
        SceneManager.instance.LoadScene(4);
    }

    public void LoadNextStage()
    {
        //stage++;

        // Unload shop
        SceneManager.instance.UnloadScene(4);

        // Load dungeon
        SceneManager.instance.LoadScene(3);
    }

    void LoadWinScreen()
    {

    }
}

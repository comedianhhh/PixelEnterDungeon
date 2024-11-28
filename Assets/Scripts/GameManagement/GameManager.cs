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

        // Load dungeon
        SceneManager.instance.LoadScene(3);
    }

    public void DungeonLoaded()
    {
        // Start game
        turnManager.StartTurnManager();
    }
}

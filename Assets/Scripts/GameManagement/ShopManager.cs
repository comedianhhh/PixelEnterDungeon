using benjohnson;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    // Components
    GridLayout gridLayout;

    protected override void Awake()
    {
        base.Awake();

        gridLayout = GetComponent<GridLayout>();
    }
    private void Start()
    {
        LoadShop();
    }

    void LoadShop()
    {

    }

    public void ExitShop()
    {
        GameManager.instance.LoadNextStage();
    }
}

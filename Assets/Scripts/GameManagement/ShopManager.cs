using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    // Components
    ArrangeGrid gridLayout;

    [SerializeField] GameObject shopItemPrefab;

    protected override void Awake()
    {
        base.Awake();

        gridLayout = GetComponent<ArrangeGrid>();


    }
    void Start()
    {
        LoadShop();
    }

    void LoadShop()
    {
        List<A_Base> artifacts = ArtifactManager.instance.GetRandomArtifacts(6);
        foreach (A_Base a in artifacts)
        {
            Instantiate(shopItemPrefab, transform).GetComponent<ShopItem>().Visualize(a);
        }
        gridLayout.Arrange();
    }

    public void ExitShop()
    {
        GameManager.instance.LoadNextStage();
    }
}

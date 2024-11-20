using System;
using System.Collections.Generic;
using UnityEngine;
using benjohnson;

public class GameAssets : Singleton<GameAssets>
{
    [SerializeField] List<GameObject> gameObjects = new List<GameObject>();

    public GameObject GetGameObject(string id)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].name == id)
                return gameObjects[i];
        }

        return null;
    }

    [SerializeField] List<Material> materials = new List<Material>();

    public Material GetMaterial(string id)
    {
        for (int i = 0; i < materials.Count; i++)
        {
            if (materials[i].name == id)
                return materials[i];
        }

        return null;
    }

    [SerializeField] List<Sprite> sprites = new List<Sprite>();

    public Sprite GetSprite(string id)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].name == id)
                return sprites[i];
        }

        return null;
    }
}

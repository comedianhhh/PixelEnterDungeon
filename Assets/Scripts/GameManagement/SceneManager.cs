using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace benjohnson
{
    public class SceneManager : Singleton<SceneManager>
    {
        protected override void Awake()
        {
            base.Awake();

            // Load game
            LoadScene(1);
        }

        public void LoadScene(int id)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);
        }

        public void UnloadScene(int id)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(id);
        }
    }
}

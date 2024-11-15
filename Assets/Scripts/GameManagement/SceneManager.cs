using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace benjohnson
{
    public class SceneManager : Singleton<SceneManager>
    {
        [SerializeField] Animator transition;

        protected override void Awake()
        {
            base.Awake();

            // Load first scene in build index
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            currentSceneIndex = 1;

            // Lock and hide cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
        int currentSceneIndex;

        public void LoadScene(int sceneIndex)
        {
            // Load Next Level
            StartCoroutine(TransitionToScene(sceneIndex));
        }

        public void LoadNextScene()
        {
            LoadScene(currentSceneIndex + 1);
        }

        IEnumerator TransitionToScene(int sceneIndex)
        {
            transition.SetBool("Transitioning", true);

            yield return new WaitForSeconds(0.5f);

            scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentSceneIndex));
            currentSceneIndex = sceneIndex;
            scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive));

            StartCoroutine(GetSceneLoadingProgress());
        }

        public IEnumerator GetSceneLoadingProgress()
        {
            for (int i = 0; i < scenesLoading.Count; i++)
            {
                while (!scenesLoading[i].isDone)
                {
                    yield return null;
                }
            }

            transition.SetBool("Transitioning", false);
        }
    }
}

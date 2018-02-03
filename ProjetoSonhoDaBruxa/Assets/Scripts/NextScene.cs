using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class NextScene : MonoBehaviour
    {

        public bool CanPressEnter = false;
        public string GameSceneName;

        public void GoToNextScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void Update()
        {
            if (!CanPressEnter)
                return;
            if (Input.anyKey)
                SceneManager.LoadScene(GameSceneName);
        }
    }
}

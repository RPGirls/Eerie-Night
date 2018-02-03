using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Pause : MonoBehaviour
    {
        private bool _isActive = false;
        public static Pause Instance = null;

        public void Awake()
        {
            if (Instance == null)//Check if instance already exists
                Instance = this;//if not, set instance to this
            else if (Instance != this)//If instance already exists and it's not this:
                Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        public void Update () {
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;
            if (_isActive) //unload
            {
                SceneManager.UnloadSceneAsync("Pause");
                _isActive = false;
            }
            else
            {
                SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
                _isActive = true;
            }
        }

        public bool IsPauseActive()
        {
            return _isActive;
        }
    }
}

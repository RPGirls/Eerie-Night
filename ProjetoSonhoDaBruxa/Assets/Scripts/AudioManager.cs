using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _audioManager;
        private SoundFade _soundFadeInOut;

        private void Awake()
        {
            if (!_audioManager)
            {
                _audioManager = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

            _soundFadeInOut = GetComponent<SoundFade>();
        }

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // called second
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Credits" || scene.name == "Menu" || scene.name == "Tutorial" || scene.name == "WinScene")
            {
                GetComponent<AudioSource>().volume = 1f;
                GetComponent<AudioSource>().mute = false;
            }
            else
            {
                StartCoroutine(_soundFadeInOut.FadeOutMusic());
            }
        }

        // called when the game is terminated
        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
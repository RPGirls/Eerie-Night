using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SoundFade : MonoBehaviour {

        [SerializeField]
        private float delay = 1f;

        public IEnumerator FadeOutMusic()
        {
            float elapsedTime = 0;
            float currentVolume = GetComponent<AudioSource>().volume;

            while (elapsedTime < delay)
            {
                elapsedTime += Time.deltaTime;
                GetComponent<AudioSource>().volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
                yield return null;
            }

            GetComponent<AudioSource>().mute = true;
        }
    }
}

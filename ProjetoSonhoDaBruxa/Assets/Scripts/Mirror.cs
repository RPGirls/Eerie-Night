using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Mirror : MonoBehaviour {
        public string WinLevel;
        public int NumberOfObjects;
        [SerializeField]
        private int _objectCounter = 0;

        public static Mirror Instance = null;

        public void Awake()
        {
            if (Instance == null)//Check if instance already exists
                Instance = this;//if not, set instance to this
            else if (Instance != this)//If instance already exists and it's not this:
                Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (_objectCounter == NumberOfObjects)
            {
                Debug.Log("Ganhou");
                SceneManager.LoadScene(WinLevel); // Se tiver tudo coletado vai pra tela final
            }
        }

        public void AddBrokenObject()
        {
            _objectCounter ++;
        }

        public int GetObjectCounter()
        {
            return _objectCounter;
        }
    }
}

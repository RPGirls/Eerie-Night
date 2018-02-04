using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Mirror : MonoBehaviour {
        public string WinLevel;
        public int NumberOfObjects;
        [SerializeField]
        private int _objectCounter = 0;

        public float WaitTimeForWin;

        public static Mirror Instance = null;
        private bool _allObrsPlaced = false;

        public void Awake()
        {
            if (Instance == null)//Check if instance already exists
                Instance = this;//if not, set instance to this
            else if (Instance != this)//If instance already exists and it's not this:
                Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        public void Update()
        {
            if (_objectCounter == NumberOfObjects && _allObrsPlaced)
            {
                StartCoroutine("WinCoroutine");
            }
        }

        private IEnumerator WinCoroutine()
        {
            Debug.Log("Ganhou");
            yield return new WaitForSeconds(WaitTimeForWin == 0 ? 0.4f : WaitTimeForWin);
            SceneManager.LoadScene(WinLevel); // Se tiver tudo coletado vai pra tela final
        }

        public void AddBrokenObject()
        {
            _objectCounter ++;
        }

        public int GetObjectCounter()
        {
            return _objectCounter;
        }

        public void CheckIfWin()
        {
            if (_objectCounter== NumberOfObjects)
                _allObrsPlaced = true;
        }
    }
}

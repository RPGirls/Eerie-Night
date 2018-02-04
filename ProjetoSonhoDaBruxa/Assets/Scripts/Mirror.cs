using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Mirror : MonoBehaviour {
        public string WinLevel;
        public int NumberOfObjectsToWin;
        [SerializeField]
        private int _objectsCollectedCounter = 0;
        [SerializeField]
        private int _objectsToCollect = 0;

        [SerializeField]
        private List<BreakableObject> _brokenObjectsList = new List<BreakableObject>();
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
            if (_objectsCollectedCounter == NumberOfObjectsToWin && _allObrsPlaced)
            {
                StartCoroutine("WinCoroutine");
            }
        }

        private IEnumerator WinCoroutine()
        {
            Debug.Log("Ganhou");
			GetComponent<AudioSource> ().Play ();
            yield return new WaitForSeconds(WaitTimeForWin == 0 ? 0.4f : WaitTimeForWin);
            SceneManager.LoadScene(WinLevel); // Se tiver tudo coletado vai pra tela final
        }

        public void AddBrokenObject(BreakableObject obj)
        {
            _objectsToCollect++;
            _objectsCollectedCounter ++;
            _brokenObjectsList.Add(obj);
        }

        public int GetObjectCounter()
        {
            return _objectsCollectedCounter;
        }

        public void DecreaseBrokenObjectsWhenDie()
        {
            foreach (var breakableObject in _brokenObjectsList)
            {
                breakableObject.ResetObject();
            }
            _objectsCollectedCounter = _objectsCollectedCounter - _objectsToCollect;
        }

        public void ResetObjectsToCollect()
        {
            _brokenObjectsList.Clear();
            _objectsToCollect = 0;
        }

        public void CheckIfWin()
        {
            if (_objectsCollectedCounter== NumberOfObjectsToWin)
                _allObrsPlaced = true;
        }
    }
}

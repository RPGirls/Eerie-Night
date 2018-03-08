using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MirrorTrigger : MonoBehaviour
    {
        [SerializeField]
        private int _orbsCounter = 0;

        public GameObject[] Orbs;
        private int _difference;
        public float WaitTimeBetweenOrbs;

        public GameObject CloseToMirror;
        public GameObject FarFromMirror;
        public GameObject WinMirror;

        public static MirrorTrigger Instance = null;
        private bool _win;

        public void Awake()
        {
            if (Instance == null)//Check if instance already exists
                Instance = this;//if not, set instance to this
            else if (Instance != this)//If instance already exists and it's not this:
                Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (_win)
                return;

            if (other.tag == "Player") {
                // Trigger close to mirror
                TriggerCloseToMirror();
                //Trigger orbs
                var orbsCollected = Mirror.Instance.GetObjectCounter();
               _difference = orbsCollected - _orbsCounter;
                StartCoroutine("StartOrbs");
                // Reset Objects To collect
                Mirror.Instance.ResetObjectsToCollect();
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (_win)
                return;

            TriggerFarFromMirror();
        }

        private void TriggerCloseToMirror()
        {
            CloseToMirror.SetActive(true);
            FarFromMirror.SetActive(false);
            WinMirror.SetActive(false);
        }

        private void TriggerFarFromMirror()
        {
            CloseToMirror.SetActive(false);
            FarFromMirror.SetActive(true);
            WinMirror.SetActive(false);
        }

        public void TriggerWinMirror()
        {
            if (WinMirror == null)
                return;
            _win = true;
          
            CloseToMirror.SetActive(false);
            FarFromMirror.SetActive(false);
            WinMirror.SetActive(true);
        }

        private IEnumerator StartOrbs()
        {
            yield return new WaitForSeconds(0.2f);
            for (int i = _orbsCounter; i < _difference; i++)
            {
                Orbs[i].SetActive(true);
                yield return new WaitForSeconds(WaitTimeBetweenOrbs);
            }
            Mirror.Instance.CheckIfWin();

        }
    }
}

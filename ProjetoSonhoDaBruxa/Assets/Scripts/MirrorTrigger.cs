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

        public void Start()
        {
            CloseToMirror.SetActive(true);
            FarFromMirror.SetActive(false);
        }

        public void OnTriggerEnter2D(Collider2D other){

            if (other.tag == "Player") {
                // Trigger close to mirror
                CloseToMirror.SetActive(true);
                FarFromMirror.SetActive(false);
                //Trigger orbs
                var orbsCollected = Mirror.Instance.GetObjectCounter();
               _difference = orbsCollected - _orbsCounter;
                StartCoroutine("StartOrbs");
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            CloseToMirror.SetActive(false);
            FarFromMirror.SetActive(true);
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

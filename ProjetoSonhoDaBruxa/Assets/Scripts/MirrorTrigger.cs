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

        public void OnTriggerEnter2D(Collider2D other){

            if (other.tag == "Player") {
                // Trigger mirror animation

                //Trigger orbs
                var orbsCollected = Mirror.Instance.GetObjectCounter();
               _difference = orbsCollected - _orbsCounter;
                Debug.Log(_difference + "diff");
                StartCoroutine("StartOrbs");
            }
        }

        private IEnumerator StartOrbs()
        {
            yield return new WaitForSeconds(0.2f);
            for (int i = _orbsCounter; i < _difference; i++)
            {
                Orbs[i].SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}

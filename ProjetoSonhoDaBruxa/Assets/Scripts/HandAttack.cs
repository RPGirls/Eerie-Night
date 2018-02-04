using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class HandAttack : MonoBehaviour {

        private bool _attacking;
    
        void Start () {
            StartCoroutine (HandAttacking());
        }
	
        void Update () {

            if (Input.GetKeyDown (KeyCode.Q)) {
			
                //gameObject.GetComponent<BoxCollider2D> ().transform.localRotation = new Vector3 (0, 0, 180f);
            }
		
        }
        IEnumerator HandAttacking() {

            while(true){
			
                //trigger animation
                if (_attacking) {
                   // gameObject.transform.Rotate (0, 0, -90);
                    _attacking = false;
                } else {
                  //  gameObject.transform.Rotate (0, 0, 90);
                    _attacking = true;
                }

                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}

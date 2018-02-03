using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandAttack : MonoBehaviour {

	private bool _attacking;

	// Use this for initialization
	void Start () {
		StartCoroutine (HandAttacking());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			
			//gameObject.GetComponent<BoxCollider2D> ().transform.localRotation = new Vector3 (0, 0, 180f);
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			//SceneManager.LoadScene("GameOver");
			Debug.Log("Perdeu");
		}
	}

	IEnumerator HandAttacking() {

		while(true){
			
			//trigger animation
			if (_attacking) {
				gameObject.transform.Rotate (0, 0, 90);
				_attacking = false;
			} else {
				gameObject.transform.Rotate (0, 0, -90);
				_attacking = true;
			}

			yield return new WaitForSeconds(1.0f);
		}
	}
}

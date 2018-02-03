using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {

	public string WinLevel;

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player") {
			//SceneManager.LoadScene (WinLevel);
			Debug.Log ("Ganhou");
		}
	}

	void OnTriggerStay2D(Collider2D other) {


	}

	void OnTriggerExit2D(Collider2D other) {


	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			// Trigger mirro animation
		}

	}
}

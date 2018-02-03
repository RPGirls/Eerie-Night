using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float PlayerPace = 2.0f;

	private Rigidbody2D _rb;

	// Use this for initialization
	void Start () {

		_rb = transform.GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
			
			_rb.velocity = new Vector2 (Vector2.left.x * PlayerPace, _rb.velocity.y); 

		} else if (Input.GetKey (KeyCode.D)) {
			
			_rb.velocity = new Vector2 (Vector2.right.x * PlayerPace, _rb.velocity.y); 
		}

		if (Input.GetKey (KeyCode.W)) {

			_rb.velocity = new Vector2 (_rb.velocity.x, Vector2.up.y * PlayerPace); 

		} else if (Input.GetKey (KeyCode.S)) {
			
			_rb.velocity = new Vector2 (_rb.velocity.x, Vector2.down.y * PlayerPace); 
		}

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.W)
		    || Input.GetKeyUp (KeyCode.S)) {

			_rb.velocity = new Vector2 (0, 0);
		}

	}
}

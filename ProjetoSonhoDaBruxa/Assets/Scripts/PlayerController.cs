using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float PlayerPace = 2.0f;

	private Rigidbody2D _rb;

	public static PlayerController Instance = null;

	public void Awake()
	{
		if (Instance == null)//Check if instance already exists
			Instance = this;//if not, set instance to this
		else if (Instance != this)//If instance already exists and it's not this:
			Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
	}

	// Use this for initialization
	void Start () {

		_rb = transform.GetComponent<Rigidbody2D> ();
		_rb.gravityScale = 0.0f;
		_rb.freezeRotation = true;

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

	public Vector3 GetPosition(){
		return transform.position;
	}

}

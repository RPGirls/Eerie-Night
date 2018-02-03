using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour {

        public float PlayerPace = 2.0f;

		public static PlayerController Instance = null;


        private Rigidbody2D _rb;
		private string _lastDirection;
		private bool _canFlip;

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

			if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) 
				|| (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))){
				_canFlip = false;
			} else {
				_canFlip = true;
			}

            if (Input.GetKey (KeyCode.A)) {
			
                _rb.velocity = new Vector2 (Vector2.left.x * PlayerPace, _rb.velocity.y); 
				if (_lastDirection != "A" && _canFlip) {
					//Flip para esquerda
					Debug.Log("Flip esquerda");
					_lastDirection = "A";
				}

            } else if (Input.GetKey (KeyCode.D)) {
			
                _rb.velocity = new Vector2 (Vector2.right.x * PlayerPace, _rb.velocity.y); 
				if (_lastDirection != "D" && _canFlip) {
					//Flip para esquerda
					Debug.Log("Flip direita");
					_lastDirection = "D";
				}
            }

            if (Input.GetKey (KeyCode.W)) {

                _rb.velocity = new Vector2 (_rb.velocity.x, Vector2.up.y * PlayerPace); 
				if (_lastDirection != "W" && _canFlip) {
					//Flip para esquerda
					Debug.Log("Flip cima");
					_lastDirection = "W";
				}

            } else if (Input.GetKey (KeyCode.S)) {
			
                _rb.velocity = new Vector2 (_rb.velocity.x, Vector2.down.y * PlayerPace); 
				if (_lastDirection != "S" && _canFlip) {
					//Flip para esquerda
					Debug.Log("Flip baixo");
					_lastDirection = "S";
				}
            }

            if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.W)
                || Input.GetKeyUp (KeyCode.S)) {

				_rb.velocity = new Vector2 (0, 0);
				// Trigger Idle
				Debug.Log("Idle animation");
            }

        }

        public Vector3 GetPosition(){
            return transform.position;
        }

    }
}

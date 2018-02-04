using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        public float PlayerPace = 2.0f;
        public float SlowerPace = 0.5f;

        public static PlayerController Instance = null;

        private Rigidbody2D _rb;
        private string _lastDirection;
        private bool _canFlip;
        public bool IsPulling;
		public bool IsMoving;

        public void Awake()
        {
            if (Instance == null) //Check if instance already exists
                Instance = this; //if not, set instance to this
            else if (Instance != this) //If instance already exists and it's not this:
                Destroy(gameObject);
                    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        public void Start()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0.0f;
            _rb.freezeRotation = true;
        }

        public void Update()
        {

            if (Pause.Instance.IsPauseActive())
                return;

            if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) ||
                 Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                ||
                (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) ||
                 Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)))
            {
                _canFlip = false;
            }
            else
            {
                _canFlip = true;
            }

			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
				IsMoving = true;
                if (IsPulling)
                    _rb.velocity = new Vector2(Vector2.left.x*SlowerPace, _rb.velocity.y);
                else
                    _rb.velocity = new Vector2(Vector2.left.x*PlayerPace, _rb.velocity.y);

                if (_lastDirection != "A" && _canFlip && !IsPulling)
                {
                    //Flip para esquerda
                    Debug.Log("Flip esquerda");
                    _lastDirection = "A";
                }
            }
			else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
				IsMoving = true;
                if (IsPulling)
                    _rb.velocity = new Vector2(Vector2.right.x*SlowerPace, _rb.velocity.y);
                else
                    _rb.velocity = new Vector2(Vector2.right.x*PlayerPace, _rb.velocity.y);
                
                if (_lastDirection != "D" && _canFlip && !IsPulling)
                {
                    //Flip para esquerda
                    Debug.Log("Flip direita");
                    _lastDirection = "D";
                }
            }
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
				IsMoving = true;
				if (IsPulling) {
					_rb.velocity = new Vector2(_rb.velocity.x, Vector2.up.y*SlowerPace);
				} else {
					_rb.velocity = new Vector2(_rb.velocity.x, Vector2.up.y*PlayerPace);
				}
                
				if (_lastDirection != "W" && _canFlip)
                {
                    //Flip para esquerda
                    Debug.Log("Flip cima");
                    _lastDirection = "W";
                }
                
            }
			else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
				IsMoving = true;
                if (IsPulling)
                    _rb.velocity = new Vector2(_rb.velocity.x, Vector2.down.y*SlowerPace);
                else
                    _rb.velocity = new Vector2(_rb.velocity.x, Vector2.down.y*PlayerPace);
                if (_lastDirection != "S" && _canFlip && !IsPulling)
                {
                    //Flip para esquerda
                    Debug.Log("Flip baixo");
                    _lastDirection = "S";
                }
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W)
                || Input.GetKeyUp(KeyCode.S))
            {
				IsMoving = false;
                _rb.velocity = new Vector2(0, 0);
                // Trigger Idle
                Debug.Log("Idle animation");
            }

        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }



    }
}

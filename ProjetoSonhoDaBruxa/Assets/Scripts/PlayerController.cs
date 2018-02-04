using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        public float PlayerPace;
        public float SlowerPace;

        public float TimeFrozenWhenRespawn;
        public float AcelerationForce;
        

		public bool IsPulling;
		public bool IsMoving;

        private Rigidbody2D _rb;
        private string _lastDirection;
        private MovementDirection _directions;
		private bool _afterPulling;
        

        public static PlayerController Instance = null;
        private Vector3 _rebornPosition;
        public bool IsDead;

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
            _directions = new MovementDirection();
        }

        public void Update()
        {

            if (Pause.Instance.IsPauseActive())
                return;

			if (_afterPulling)
				return;
			

            if (!_directions.Left || !_directions.Right || !_directions.Up || !_directions.Down || IsDead)
            {
                IsMoving = false;
                _rb.velocity = new Vector2(0, 0);
            }

            if(IsDead)
                return;
			
			GetKeys();

            GetKeysUp();
        }

        private void GetKeysUp()
        {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                _directions.Left = false;
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                _directions.Right = false;
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                _directions.Up = false;
            else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                _directions.Down = false;
        }

        private void GetKeys()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                GoingLeft();
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                GoingRight();
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                GoingUp();
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
                GoingDown();
        }

        private void GoingDown()
        {
            _directions.Down = true;
            IsMoving = true;
            SetVelocityUpDown(Vector2.down);
           
        }

        private void GoingUp()
        {
            _directions.Up = true;
            IsMoving = true;
            SetVelocityUpDown(Vector2.up);
          
        }

        private void SetVelocityUpDown( Vector2 yVector)
        {
            if (IsPulling)
                _rb.velocity = new Vector2(_rb.velocity.x, yVector.y * SlowerPace);
            else
                _rb.velocity = new Vector2(_rb.velocity.x, yVector.y * PlayerPace);
        }

        private void GoingRight()
        {
            _directions.Right = true;
            IsMoving = true;
            SetVelocityLeftRight(Vector2.right);
            if (_lastDirection != "D" && !IsPulling)
            {
				if (transform.localScale.x > 0) {
					transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
                _lastDirection = "D";
            }

			//if (transform.localScale.x < 0 && IsPulling) 
			//	transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        private void GoingLeft()
        {
            _directions.Left = true;
            IsMoving = true;
            SetVelocityLeftRight(Vector2.left);
            if (_lastDirection != "A" && !IsPulling)
            {
				if (transform.localScale.x < 0) {
					transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
                _lastDirection = "A";
            }

			//if (transform.localScale.x > 0 && IsPulling) 
				//transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			
        }

        private void SetVelocityLeftRight(Vector2 xVector)
        {
            if (IsPulling)
                _rb.velocity = new Vector2(xVector.x * SlowerPace, _rb.velocity.y);
            else
                _rb.velocity = new Vector2(xVector.x * PlayerPace, _rb.velocity.y);
        }

        public void Die(Vector3 position)
        {
            IsDead = true;
            IsMoving = false;
            _rebornPosition = position;
        }

        public void Reborn()
        {
            IsDead = false;
            transform.position = _rebornPosition;
        }

        public void ApplyForce()
		{
			_afterPulling = true;
		    if (_directions.Up)
				StartCoroutine("AddForce", Vector2.up);
            if (_directions.Down)
				StartCoroutine("AddForce", Vector2.down);
            if (_directions.Right)
				StartCoroutine("AddForce", Vector2.right);
            if (_directions.Left)
				StartCoroutine("AddForce", Vector2.left);
        }

        IEnumerator AddForce(Vector2 direction)
        {
			_rb.AddForce(direction * AcelerationForce, ForceMode2D.Impulse);

			yield return new WaitForSeconds (.5f);

			_afterPulling = false;
        }

        private struct MovementDirection
        {
            public bool Up, Down, Left, Right;

        }
        

    }
}

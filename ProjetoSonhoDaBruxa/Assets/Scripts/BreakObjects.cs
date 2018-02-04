using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Assets.Scripts
{
    public class BreakObjects : MonoBehaviour {
    
        public float Radius;
        [Tooltip("Tempo para segurar espaço")]
        public float HoldTime; 

        public Light Light;

        private float _startTime = 0f;
        private bool _ready;
        private float _pressTime;
		private PlayerController _playerControl;

		public void Start(){

			_playerControl = PlayerController.Instance;
		}

        public void Update()
        {
            if (Pause.Instance.IsPauseActive())
                return;

            Collider2D col = FindNearestObject();

            if (Input.GetKeyDown(KeyCode.Space) && _ready == false && col !=null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StillPressing();
                }
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.S) || col == null)
            {
                StoppedPressing();
            }
            if (Time.time >= _pressTime && _ready)
            {
                PressedEnoughTime(col);
            }

        }

        private void StillPressing()
        {
            _startTime = Time.time;
            _pressTime = _startTime + HoldTime;
            _playerControl.IsPulling = true;
            _ready = true;
            ShowLight();
            //StartParticle();
        }

        private void StoppedPressing()
        {
            _ready = false;
            EndLight();
            //StopParticle();
            _playerControl.IsPulling = false;
        }

        private void PressedEnoughTime(Collider2D col)
        {
            _ready = false;
            BreakObject(col);
            _playerControl.IsPulling = false;
        }

        private void StopParticle()
        {
            throw new System.NotImplementedException();
        }

        private void StartParticle()
        {
            throw new System.NotImplementedException();
        }

        private void ShowLight()
        {
            Light.color = Color.red;
        }

        private void EndLight()
        {
            Light.color = Color.white;
        }

        private void FindObjectAndBreak()
        {
            Collider2D col = FindNearestObject();
            if (col != null)
                BreakObject(col);
        }

        private void BreakObject(Collider2D col)
        {
            Mirror.Instance.AddBrokenObject();
            col.GetComponent<BreakableObject>().BreakObject();
        }

        Collider2D FindNearestObject()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Radius);

            Collider2D nearestCollider = null;
            float minSqrDistance = Mathf.Infinity;

            foreach (Collider2D col in colliders)
            {
                float sqrDistanceToCenter = (transform.position - col.transform.position).sqrMagnitude;

                if (sqrDistanceToCenter < minSqrDistance && col.CompareTag("Interactive"))
                {
                    minSqrDistance = sqrDistanceToCenter;
                    nearestCollider = col;
                }
            }
            return nearestCollider;
        }


        public void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}

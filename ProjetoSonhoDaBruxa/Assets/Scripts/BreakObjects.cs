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

		void Start(){

			_playerControl = PlayerController.Instance;
		}

        public void Update()
        {
            if (Pause.Instance.IsPauseActive())
                return;
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.S) && _ready == false)
            {
                _startTime = Time.time;
                _pressTime = _startTime + HoldTime;
				_playerControl._isPulling = true;
                _ready = true;
                ShowLight();
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.S))
            {
                _ready = false;
                EndLight();
				_playerControl._isPulling = false;
            }
            if (Time.time >= _pressTime && _ready)
            {
                _ready = false;
                FindObjectAndBreak();
				_playerControl._isPulling = false;
            }

        }

        private void EndLight()
        {
            Light.color = Color.white;
        }

        private void ShowLight()
        {
            Light.color = Color.red;
        }

        private void FindObjectAndBreak()
        {
            Collider2D col = FindObject();
            if (col != null)
                BreakObject(col);
        }

        private void BreakObject(Collider2D col)
        {
            Mirror.Instance.AddBrokenObject();
            col.GetComponent<BreakableObject>().BreakObject();
        }

        Collider2D FindObject ()
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

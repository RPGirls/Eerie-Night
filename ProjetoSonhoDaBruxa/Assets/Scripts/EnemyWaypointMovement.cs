using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyWaypointMovement : MonoBehaviour
    {
        public Vector3[] Points;
        public float Speed;
        private float _startTime;
        private Vector3 _currentWaypoint;
        private int _pointsIterator = 0;
        private bool _changedWaypoint = false;

        public void Start()
        {
            _startTime = Time.time;
            _currentWaypoint = Points[0];
        }

        public void Update () {
            if (Vector3.Distance(transform.position, _currentWaypoint) <= 0.02 && !_changedWaypoint)
            {
                ChangeWayPoint();
                _changedWaypoint = true;
                return;
            }

            var journeyLength = Vector3.Distance(transform.position, _currentWaypoint);
            var distCovered = (Time.time - _startTime) * Speed; // Distance moved = time * speed.
            var fracJourney = distCovered / journeyLength; // Fraction of journey completed = current distance divided by total distance.
            
			transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint, Time.deltaTime * Speed);

            _changedWaypoint = false;
        }

        private void ChangeWayPoint()
        {
            _pointsIterator ++;
			if (_pointsIterator == Points.Length) {
				_pointsIterator = 1;
				System.Array.Reverse (Points);

			}
            _currentWaypoint = Points[_pointsIterator];
        }

          public void OnDrawGizmos()
          {
              foreach (var point in Points)
              {
                  Gizmos.color = Color.magenta;
                  Gizmos.DrawWireSphere(point, .2f);
              }
          } 
    }
}

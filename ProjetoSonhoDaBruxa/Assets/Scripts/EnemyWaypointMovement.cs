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


        public void Start()
        {
            _startTime = Time.time;
            _currentWaypoint = Points[0];
        }

        public void Update () {
            if (transform.position == _currentWaypoint)
            {
                ChangeWayPoint();
                return;
            }

            var journeyLength = Vector3.Distance(transform.position, _currentWaypoint);
            var distCovered = (Time.time - _startTime) * Speed; // Distance moved = time * speed.
            var fracJourney = distCovered / journeyLength; // Fraction of journey completed = current distance divided by total distance.
            
            transform.position = Vector3.Lerp(transform.position, _currentWaypoint, Speed);
        }

        private void ChangeWayPoint()
        {
            _pointsIterator ++;
            if (_pointsIterator == Points.Length)
                _pointsIterator = 0;
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

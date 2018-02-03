using UnityEngine;

namespace Assets.Scripts
{
    public class BreakObjects : MonoBehaviour {
    
        public float Radius;
    
        // Interactive

        // Objetos quebram e soltam uma particula em direção ao player

        // Update is called once per frame
        public void Update () {

            if(Input.GetKeyDown (KeyCode.Space)){
                Collider2D col = FindObject ();
                if (col != null)
                    BreakObject(col);
            }

        }

        private void BreakObject(Collider2D col)
        {
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

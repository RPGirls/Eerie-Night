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
                Collider col = FindObject ();
            }

        }

        Collider FindObject ()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);

            Debug.Log (transform.position + " posicao player");

            Collider nearestCollider = null;
            float minSqrDistance = Mathf.Infinity;

            for (int i = 0; i < colliders.Length; i++)
            {
                float sqrDistanceToCenter = (transform.position - colliders[i].transform.position).sqrMagnitude;

                if (sqrDistanceToCenter < minSqrDistance)
                {
                    minSqrDistance = sqrDistanceToCenter;
                    nearestCollider = colliders[i];
                }
            }

            Debug.Log (minSqrDistance + " Distancia");
            return nearestCollider;
        }


        public void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}

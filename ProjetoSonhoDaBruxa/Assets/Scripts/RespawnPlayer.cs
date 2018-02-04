
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class RespawnPlayer : MonoBehaviour
    {
        public Vector3 SpawnPoint;

        public static RespawnPlayer Instance = null;

        public void Awake()
        {
            if (Instance == null)//Check if instance already exists
                Instance = this;//if not, set instance to this
            else if (Instance != this)//If instance already exists and it's not this:
                Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        public void EndGame()
        {
            PlayerController.Instance.Die(SpawnPoint); //Se nao tiver coletado Respawn
        }
        

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(SpawnPoint, 0.3f);
        }
    }
}

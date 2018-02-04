using UnityEngine;

namespace Assets.Scripts
{
    public class TriggerEndGame : MonoBehaviour {
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "EnemyCollider")
            {
                Mirror.Instance.DecreaseBrokenObjectsWhenDie();
                RespawnPlayer.Instance.EndGame();
            }
        }

    }
}

using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour {

        public GameObject Player;
    
        // Update is called once per frame
        public void Update () {
		
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        }
    }
}

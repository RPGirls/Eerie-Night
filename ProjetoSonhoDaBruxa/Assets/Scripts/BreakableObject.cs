using UnityEngine;

namespace Assets.Scripts
{
    public class BreakableObject : MonoBehaviour {

        public Sprite BrokenObject;

        public void BreakObject()
        {
            GetComponent<SpriteRenderer>().sprite = BrokenObject;
        }
    }
}

using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class BreakableObject : MonoBehaviour {

        public Sprite BrokenObject;
        private Animator _anim;

        public void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void BreakObject()
        {
            if(_anim != null)
                _anim.SetBool("break", true);
            GetComponent<SpriteRenderer>().sprite = BrokenObject;
            tag = "Untagged";
        }
    }
}

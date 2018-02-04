using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class BreakableObject : MonoBehaviour {
        
        private Animator _anim;

        public void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void BreakObject()
        {
            if(_anim != null)
                _anim.SetBool("Broken", true);
            GetComponent<Collider2D>().enabled = false;
            tag = "Untagged";
        }

        public void ResetObject()
        {
            if (_anim != null) 
                _anim.SetBool("Broken", false);
            GetComponent<Collider2D>().enabled = true;
            tag = "Interactive";
        }
    }
}

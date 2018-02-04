using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class BreakableObject : MonoBehaviour {
	        
        private Animator _anim;
		private AudioSource _audioSource;

        public void Start()
        {
			_audioSource = GetComponent<AudioSource> ();
            _anim = GetComponent<Animator>();
        }

        public void BreakObject()
        {
            if(_anim != null)
                _anim.SetBool("Broken", true);
			_audioSource.Play ();
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

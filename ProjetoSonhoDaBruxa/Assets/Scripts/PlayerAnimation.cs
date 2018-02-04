using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour {

        private Animator _anim;
        
        public void Start () {
            _anim = gameObject.GetComponentInChildren(typeof(Animator)) as Animator;
        }
	
        public void Update ()
        {
            var control = PlayerController.Instance;
            _anim.SetBool("IsWalking", control.IsMoving);
            _anim.SetBool("Idle", !control.IsMoving);
            _anim.SetBool("Power", BreakObjects.Instance.GetIfPressingButtonsToBreakObjects());
            _anim.SetBool("Dead", control.IsDead);
        }
    }
}

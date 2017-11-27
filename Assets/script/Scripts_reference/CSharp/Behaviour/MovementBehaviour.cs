using UnityEngine;
using System.Collections;

public class MovementBehaviour : StateMachineBehaviour {
	void OnStateEnter(Animator anim, AnimatorStateInfo info, int id){
    	anim.ResetTrigger("Skill") ;
    	anim.SetBool("Shot", false) ;
    	anim.GetComponentInParent<Controller>().lockMove = false ;
  	}
  	
  	void OnStateUpdate(Animator anim, AnimatorStateInfo info, int id){
    	Game.sav.RegenSP(Time.deltaTime) ;
  	}
}

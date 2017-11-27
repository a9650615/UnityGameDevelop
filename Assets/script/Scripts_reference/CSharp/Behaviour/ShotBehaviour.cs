using UnityEngine;
using System.Collections;

public class ShotBehaviour : StateMachineBehaviour {
	
	void OnStateUpdate(Animator anim, AnimatorStateInfo info, int id){
    	anim.GetComponentInParent<Rigidbody2D>().drag = 20 ;
  	}
  	void OnStateExit(Animator anim, AnimatorStateInfo info, int id){
    	anim.GetComponentInParent<Rigidbody2D>().drag = 0 ;
  	}
}

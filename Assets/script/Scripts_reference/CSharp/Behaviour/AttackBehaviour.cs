using UnityEngine;
using System.Collections;

public class AttackBehaviour : StateMachineBehaviour {

	public float transhold = 1.0f ;
  	public int order = 0 ;
  
  	void OnStateUpdate(Animator anim, AnimatorStateInfo info, int id){
		if(info.normalizedTime <= transhold){
			anim.SetInteger("Attack", order) ;
		}
	}
  
	void OnStateExit(Animator anim, AnimatorStateInfo info, int id){
		anim.SetInteger("Attack", 0) ;
	}
}

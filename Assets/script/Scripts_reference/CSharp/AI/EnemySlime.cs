using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : Enemy {
	void Update () {
		StateMachine() ;
		if(target != null){
			nav.Follow(target) ;
		}
	}
	
	public override void StateMachine(){
		anim.SetBool("moving", nav.moving) ;
		anim.SetBool("attack", nav.ReachGoal() && target!=null) ;
		nav.enableMove = !state.IsTag("attack") ;
	}
	
	public override void Damage(float dmg){
		if(!this.enabled){return;}
		
		base.Damage(dmg) ;
		anim.SetTrigger("Hurt") ;
		
		if(hp <= 0){
			anim.SetTrigger("Die") ;
			Destroy(nav) ;
			this.enabled = false ;
		}
	}
}

#pragma strict

class MovementBehaviour extends StateMachineBehaviour{
  function OnStateEnter(anim:Animator, info:AnimatorStateInfo, id:int){
    anim.ResetTrigger("Skill") ;
    anim.SetBool("Shot", false) ;
    anim.GetComponentInParent.<Controller>().lockMove = false ;
  }
  
  function OnStateUpdate(anim:Animator, info:AnimatorStateInfo, id:int){
    Game.sav.RegenSP(Time.deltaTime) ; 
  }
}

#pragma strict

class AttackBehaviour extends StateMachineBehaviour{
  var transhold : float = 1 ;
  var order : int = 0 ;
  
  function OnStateUpdate(anim:Animator, info:AnimatorStateInfo, id:int){
    if(info.normalizedTime <= transhold){
      anim.SetInteger("Attack", order) ;
    }
  }
  
  function OnStateExit(anim:Animator, info:AnimatorStateInfo, id:int){
    anim.SetInteger("Attack", 0) ;
  }
}

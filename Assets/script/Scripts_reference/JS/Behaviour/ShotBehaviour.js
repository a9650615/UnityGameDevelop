#pragma strict

class ShotBehaviour extends StateMachineBehaviour{
  function OnStateUpdate(anim:Animator, info:AnimatorStateInfo, id:int){
    anim.GetComponentInParent.<Rigidbody2D>().drag = 20 ;
  }
  function OnStateExit(anim:Animator, info:AnimatorStateInfo, id:int){
    anim.GetComponentInParent.<Rigidbody2D>().drag = 0 ;
  }
  
}

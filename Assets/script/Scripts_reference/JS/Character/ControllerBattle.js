#pragma strict

class ControllerBattle extends Controller{
  function Control(){
    super() ;
    
    if(Input.GetKeyDown(KeyCode.Z)){
      Move(0) ;
      lockMove = true ;
      anim.SetInteger("Attack", anim.GetInteger("Attack")+1) ;
    }
    
    if(Input.GetKeyDown(KeyCode.C)){
      StarBurst() ;
    }
    
    if(Input.GetKeyDown(KeyCode.X)){
      Move(0) ;
      lockMove = true ;
      body.velocity.y = 0 ;
      anim.SetBool("Shot", true) ;
    }
    
    if(Input.GetKeyUp(KeyCode.X)){
      anim.SetBool("Shot", false) ;
    }
  }
  
  function StarBurst(){
    if(!Game.sav.CanUseSkill()){return ;}
    Move(0) ;
    lockMove = true ;
    anim.SetTrigger("Skill") ;
  }
  
  function Jump(){
    if(lockMove){return;}
    super() ;
  }
  
  function Move(i:int){
    if(!lockMove){
      body.velocity.x = i*speed*Time.deltaTime ;
    }
    anim.SetFloat("Move", Mathf.Abs(i)) ;
  }
  
  function Direction(i:int){
    if(lockMove && !state.IsTag("free")){return ;}
    super(i) ;
  }
  
}

using UnityEngine;
using System.Collections;

public class ControllerBattle : Controller {
	public GameObject bulletObject ;
	
	public override void Control(){
		base.Control() ;
		
		if(state.IsName("Base.Damage")){return ;}
    
		if(Input.GetKeyDown(KeyCode.Z) && !btn){
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
			body.velocity = new Vector2(body.velocity.x, 0) ;
			anim.SetBool("Shot", true) ;
		}
    
		if(Input.GetKeyUp(KeyCode.X)){
			anim.SetBool("Shot", false) ;
		}
	}
  
  	public void StarBurst(){
		if(!Game.sav.CanUseSkill()){return ;}
    	Move(0) ;
    	lockMove = true ;
    	anim.SetTrigger("Skill") ;
  	}
  
  	public override void Jump(){
    	if(lockMove){return;}
    	base.Jump() ;
  	}
  
  	public override void Move(int i){
    	if(!lockMove){
      		body.velocity = new Vector2(i*speed*Time.deltaTime, body.velocity.y) ;
    	}
    	anim.SetFloat("Move", Mathf.Abs(i)) ;
  	}
  
  	public override void Direction(int i){
    	if(lockMove && !state.IsTag("free")){return ;}
    	base.Direction(i) ;
  	}
  	
	//=======
	// 事件
	//=======
	public override void Shot(){
		base.Shot() ;
		Transform pt = transform.Find("bulletPoint") ;
		Instantiate(bulletObject, pt.position, pt.rotation) ;
	}
	
	public void Damage(float dmg){
		if(state.IsName("Base.Damage")){return ;}
		Move(0) ;
		lockMove = true ;
		
		if(Game.sav.Damage(dmg) <= 0){
			// Die
			anim.SetTrigger("Die") ;
			gameObject.layer = 0 ;
			this.enabled = false ;
			StartCoroutine(Reload()) ;
		}else{
			// Damage
			anim.SetTrigger("Damage") ;
		}
		
	}
	
	public IEnumerator Reload(){
		yield return new WaitForSeconds(3) ;
		Game.screen().FadeAndGo(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name) ;
		Game.Reset() ;
	}
}

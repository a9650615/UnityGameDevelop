using UnityEngine;

public class EnemyBoss : Enemy {
    public Transform cannonPoint ;
    public Transform[] locators ;
    public GameObject bullet ;

	public override void Start() {
		
	}
    
    void Update(){
        StateMachine() ;
        
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            nav.MoveTo(locators[0].position) ;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            nav.MoveTo(locators[1].position) ;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Shot() ;
        }
    }
    
    public override void StateMachine(){
        anim.SetBool("moving", nav.moving) ;
    }
    
    public void Shot(){
        anim.SetTrigger("attack") ;
    }
    
    public void Cannon(){
        Instantiate(bullet, cannonPoint.position, cannonPoint.rotation) ;
    }
}

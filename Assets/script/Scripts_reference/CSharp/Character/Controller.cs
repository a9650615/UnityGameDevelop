using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public float speed = 140f ;
	public float jumpHeight = 15f ;
	
	public GameObject buttonObject ;
	internal GameObject btn ;

	internal bool isGround = false ;
	internal Rigidbody2D body ;
	internal Animator anim ;
	internal AnimatorStateInfo state ;
	internal bool lockMove = false ;

	public void Awake(){
		Physics2D.IgnoreLayerCollision(9,10) ;
		Physics2D.IgnoreLayerCollision(9,11) ;
		Physics2D.IgnoreLayerCollision(11,11) ;
		// 取得各類元件
		body = GetComponent<Rigidbody2D>() ;
		anim = GetComponentInChildren<Animator>() ;
	}

	public void Update(){
		if(!(Game.pause || state.IsName("Base.Damage"))){
			Control() ;
		}
		StateMachine() ;
	}

	public virtual void Control(){
		bool upKey = Input.GetKeyUp(KeyCode.RightArrow) ||
		Input.GetKeyUp(KeyCode.LeftArrow) ;

		if(Input.GetKey(KeyCode.RightArrow)){
			Move(1) ;
			Direction(0) ;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			Move(-1) ;
			Direction(1) ;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			Jump() ;
		}
		if(upKey){
			Move(0) ;
		}
	}

	//=======
	// 行動
	//=======
	public virtual void Jump(){
		if(!isGround){return;}
		body.velocity = new Vector2(body.velocity.x, jumpHeight) ;
		anim.SetTrigger("Jump") ;
	}

	public virtual void Move(int i){
		body.velocity = new Vector2(i*speed*Time.deltaTime, body.velocity.y) ;
		anim.SetFloat("Move", Mathf.Abs(i+0f)) ;
	}

	public virtual void Direction(int i){
		transform.eulerAngles = new Vector3(0, 180f*i, 0) ;
	}

	//==========
	// 動畫
	//==========
	public void StateMachine(){
		anim.SetBool("Ground", isGround) ;
		anim.SetFloat("Y", body.velocity.y) ;
		anim.SetFloat("Ammo", Game.sav.HasAmmo() ? 1:0) ;
		state = anim.GetCurrentAnimatorStateInfo(0) ;
	}

	//=======
	// 碰撞
	//=======
	void OnCollisionStay2D(Collision2D col){
		if(col.contacts[0].normal != Vector2.up){return;}
		isGround = true ;
	}

	void OnCollisionExit2D(Collision2D col){
		isGround = false ;
	}

	//=======
	// 事件
	//=======
	public void UseSkill(){
		Game.sav.CostSP(Game.sav.skillCost) ;
	}

	public virtual void Shot(){
		Game.sav.CostSP(Game.sav.ammoCost) ;
	}
	
	public void SpawnButton(){
		btn = Instantiate(buttonObject) ;
	}
	
	public void DestroyButton(){
		Destroy(btn) ;
	}
}

using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float hp = 10 ;
	public float atk = 1 ;
	public Vector2 detectRange = new Vector2(10,5) ;
	public float searchInterval = 1 ;

	internal Transform target ;

	// Component
	internal Animator anim ;
	internal Navigation2D nav ;
	internal AnimatorStateInfo state ;

	public virtual void Awake(){
		nav = GetComponent<Navigation2D>() ;
		anim = GetComponent<Animator>() ;
	}

	public virtual void Start(){
		StartCoroutine("SearchTimer") ;
	}

	public void SearchPlayer(){
		Collider2D[] hits = new Collider2D[1] ;
		int result = Physics2D.OverlapBoxNonAlloc(transform.position, detectRange, 0, hits, 1<<9) ;
		if(result > 0){
			target = Game.player() ;
			StopCoroutine("SearchTimer") ;
		}
	}

	public IEnumerator SearchTimer(){
		while(true){
			yield return new WaitForSeconds(searchInterval) ;
			SearchPlayer() ;
		}
	}

	public virtual void StateMachine(){}
	
	public virtual void Damage(float dmg){
		hp -= dmg ;
	}
	
	public void Die(){
		Destroy(gameObject) ;
	}
}

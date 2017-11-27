using UnityEngine;
using System.Collections;

public class CoinObject : MonoBehaviour {
	public int amount = 1 ;
	
	void OnTriggerEnter2D(Collider2D co){
		if(co.tag != "Player"){return;}
		Game.sav.GainMoney(1) ;
		GetComponent<Animator>().SetTrigger("Eat") ;
		Destroy(this) ;
	}
}

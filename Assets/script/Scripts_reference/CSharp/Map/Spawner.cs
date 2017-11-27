using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject target ;
	public int number = 1 ;
	public float delay = 0.1f ;

	Collider2D box ;

	void Awake(){
		box = GetComponent<Collider2D>() ;
	}

	public void Spawn(){
		Vector3 max = box.bounds.max ;
		Vector3 min = box.bounds.min ;
		Vector3 pos = transform.position ;
		pos.x = Random.Range(min.x, max.x) ;
  
		Instantiate(target, pos, transform.rotation) ;
	}

	public IEnumerator DelaySpawn(){
		for(var i=0 ; i<number ; i++){
			Spawn() ;
			yield return new WaitForSeconds(delay) ;
		}
	}

	public void CallSpawn(){
		DelaySpawn() ;
	}
}

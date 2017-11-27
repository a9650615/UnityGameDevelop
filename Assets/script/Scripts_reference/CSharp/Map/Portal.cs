using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class Portal : MonoBehaviour {
	public string map ;
	
	void OnTriggerEnter2D (Collider2D co) {
		if(co.tag != "Player") return ;
		SceneManager.LoadScene(map, LoadSceneMode.Additive) ;
		SceneManager.UnloadSceneAsync(gameObject.scene) ;
	}
	
	void Update(){
	
		int num = 0 ;
		while(num == 7){
			num = Random.Range(1,14) ;
		}
		
		
	}
}

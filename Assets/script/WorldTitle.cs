using UnityEngine;
using System.Collections;

public class WorldTitle : MonoBehaviour {
	public GameObject btns ;
	public GameObject anyKeyText ;
  
	void Update(){
		// 按下任意鍵
		if(Input.anyKey){
			btns.SetActive(true) ;
			anyKeyText.SetActive(false) ;
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement ;
using UnityEngine.UI ;

public class ScreenUI : MonoBehaviour {
	public Image black ;
	float speed = -0.12f ;
	
	public void Awake(){
  		FadeIn() ;
	}

	public void Update(){
		Color c = black.color ;
  		c.a += speed ;
  		c.a = Mathf.Clamp01(c.a) ;
  		black.color = c ;
	}

	// 淡入淡出
	public void FadeIn(){
		Color c = black.color ;
  		c.a = 1 ;
  		black.color = c ;
  		speed = -Mathf.Abs(speed) ;
	}

	public void FadeOut(){
  		Color c = black.color ;
  		c.a = 0 ;
  		black.color = c ;
  		speed = Mathf.Abs(speed) ;
	}

	// 淡化+轉場
	public void FadeAndGo(string map){
  		StartCoroutine(Go(map)) ;
	}
	
	public void FadeAndGo(int map){
  		StartCoroutine(Go(map)) ;
	}
	
	IEnumerator Go(string map){
		FadeOut() ;
  		yield return new WaitForSeconds(0.7f) ;
  		SceneManager.LoadScene(map) ;
	}
	
	IEnumerator Go(int map){
		FadeOut() ;
  		yield return new WaitForSeconds(0.7f) ;
  		SceneManager.LoadScene(map) ;
	}
}

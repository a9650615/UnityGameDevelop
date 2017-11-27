#pragma strict
import UnityEngine.SceneManagement ;

var black : UI.Image ;
private var speed : float = -0.02 ;

function Awake(){
  FadeIn() ;
}

function Update(){
  black.color.a += speed ;
  black.color.a = Mathf.Clamp01(black.color.a) ;
}

// 淡入淡出
function FadeIn(){
  black.color.a = 1 ;
  speed = -Mathf.Abs(speed) ;
}

function FadeOut(){
  black.color.a = 0 ;
  speed = Mathf.Abs(speed) ;
}

// 淡化+轉場
function FadeAndGo(map:String){
  FadeOut() ;
  yield WaitForSeconds(0.9) ;
  SceneManager.LoadScene(map) ;
}

function FadeAndGo(map:int){
  FadeOut() ;
  yield WaitForSeconds(0.9) ;
  SceneManager.LoadScene(map) ;
}

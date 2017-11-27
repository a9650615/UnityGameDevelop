#pragma strict
import UnityEngine.SceneManagement ;

var sceneName : String = "" ;
var sceneId : int = 0 ;

function GoTo(){
  if(sceneName == ""){
    Game.screen().FadeAndGo(sceneId) ;
  }else{
    Game.screen().FadeAndGo(sceneName) ;
  }
}

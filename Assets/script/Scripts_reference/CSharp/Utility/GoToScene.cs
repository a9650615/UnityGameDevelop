using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour {

	public string sceneName = "" ;
	public int sceneId = 0 ;

	public void GoTo(){
  		if(sceneName == ""){
    		Game.screen().FadeAndGo(sceneId) ;
  		}else{
    		Game.screen().FadeAndGo(sceneName) ;
  		}
	}
}

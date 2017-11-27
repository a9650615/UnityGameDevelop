using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    internal SoundManager sound ;
	internal MainUI ui ;
	internal DialogUI dialog ;

	void Awake(){
		sound = FindObjectOfType<SoundManager>() ;
		ui = FindObjectOfType<MainUI>() ;
		dialog = FindObjectOfType<DialogUI>() ;
	}
	
	public void StartTalk(int storyID){
		Game.pause = true ;
		ui.gameObject.SetActive(false) ;
		dialog.enabled = true ;
		dialog.StartTalk(storyID) ;
	}

	public void EndTalk(){
		Game.pause = false ;
		ui.gameObject.SetActive(true) ;
	}
}

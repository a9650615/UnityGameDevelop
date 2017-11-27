using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour {
	public Talk talk ;
	public TextAsset[] stories ;
	// 立繪圖片元件
	public Image portrait ;
	public Image portrait2 ;
	// 立繪圖片組
	public Sprite[] myFace ;
	public Sprite[] misakiFace ;
	// 其他角色立繪組
	public List<Sprite[]> otherFace = new List<Sprite[]>() ;
	// 元件
	Animation anim ;
	World world ;

	void Awake(){
		anim = GetComponent<Animation>() ;
		world = FindObjectOfType<World>() ;
		otherFace.Add(misakiFace) ;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Z)){
    		talk.Next() ;
  		}
	}
	// 顯示/隱藏對話
	public void Show(bool b){
		string Name = "ShowDialog" ;
		anim[Name].speed = b ? 1:-1 ;
  
		if(!anim.isPlaying){
			anim[Name].normalizedTime = b ? 0:1 ;
		}
		anim.Play() ;
	}
	// 開始對話
	public void StartTalk(int id){
		Show(true) ;
		talk.story = stories[id].text.Split("\n"[0]) ;
		talk.wordID = 0 ;
		talk.Next() ;
	}
	// 結束對話
	public IEnumerator CallEndTalk(){
		Show(false) ;
		this.enabled = false ;
		yield return new WaitForSeconds(1f) ;
		world.EndTalk() ;
	}
	// 換表情
	public void ChangeFace(int who,int face){
		if(who == 0){
			portrait.sprite = myFace[face] ;
		}else{
			portrait2.sprite = otherFace[who-1][face] ;
		}
	}
}

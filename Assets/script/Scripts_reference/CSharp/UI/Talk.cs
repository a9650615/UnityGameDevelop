using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour {
	public Text Name ;
	public Text text ;
	public DialogUI dialog ;
	public string[] names ;
	internal string[] story ; 	// 總劇本
	internal int wordID = 0 ; 	// 句子的id
	internal int charaID = 0 ; 	// 單句文字的id
	internal string word ;  	// 完整句子
	internal bool timer = false ;  // 計時器啟動與否

	public void Next(){
		// 如果正在打字，則直接顯示完整文字
		if(timer){
			text.text = word ;
			timer = false ;
			return ;
		}
		// 如果到達文件最後，則結束對話
		if(wordID >= story.Length-1){
			dialog.StartCoroutine(dialog.CallEndTalk()) ;
			return ;
		}
		// 設定完整文字
		word = story[wordID] ;
		// 判斷指令或者對話
		if(word[0] == '@'){
			dialog.ChangeFace(int.Parse(word[1].ToString()), int.Parse(word[3].ToString())) ;
			wordID ++ ;
			Next() ;
			return ;
		}else{
			ChangeName(int.Parse(word[0].ToString())) ;
			StartCoroutine(Print()) ;
			wordID ++ ;
		}
	}
	// 打字機
	IEnumerator Print(){
		// 初始化打字機
		charaID = 0 ;
		word = word.Substring(2) ;
		text.text = "" ;
		timer = true ;
		// 打字機迴圈
		while(timer){
			text.text += word[charaID] ;
			charaID ++ ;
			// 如果打字結束
			if(charaID >= word.Length){
				timer = false ;
				break ;
			}
			// 打字速度
			yield return new WaitForSeconds(0.07f) ;
		}
	}
	// 改名字
	void ChangeName(int who){
		Name.text = names[who] ;
	}
}

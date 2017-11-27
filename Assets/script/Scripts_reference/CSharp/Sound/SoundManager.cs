using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource bgm ; // BGM元件
	public AudioSource se ; // SE元件

	// 播放音效
	public void PlaySE(AudioClip au){
  		se.PlayOneShot(au) ;
	}
}

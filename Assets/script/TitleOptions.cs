using UnityEngine;
using System.Collections;
using Game.SplashScreen;
using Game.Setting;

public class TitleOptions : MonoBehaviour {

	public Transform hand ;
	public Transform[] buttons ;
	public float[] xOffset ;
    public AudioClip moveSound ;
    public AudioClip okSound ;
    public AudioSource se; // SE元件
    public FadeInOut _fadeInOut;
    //public World _world ;
	int id = 0 ;

	void Start () {
        _fadeInOut = FindObjectOfType<FadeInOut>();
        //_world = FindObjectOfType<World>() ;
        //_soundManager = FindObjectOfType<SoundManager>();
		id = 1 ;
		UpdatePosition() ;
	}

	void Update () {
		// 選單選擇
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			id -- ;
			id = Mathf.Clamp(id,0 ,2) ;
            //_soundManager.PlaySE(moveSound) ;
            se.PlayOneShot(moveSound);
			UpdatePosition() ;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			id ++ ;
			id = Mathf.Clamp(id,0 ,2) ;
            //_soundManager.PlaySE(moveSound) ;
            se.PlayOneShot(moveSound);
			UpdatePosition() ;
		}
        //確定

        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (id)
            {
                // new
                case 0:
                    //Game.screen().FadeAndGo("Map");
                    if (_fadeInOut)
                        _fadeInOut.FadeAndGo(Setting.Scene.Game);
                    else
                        Debug.Log("Warring: Nothing be loaded!!");
                    this.enabled = false;
                    break;
                // load
                case 1:
                    break;
                // exit
                case 2:
                    Application.Quit();
                    break;
            }
            se.PlayOneShot(okSound);
        }

    }

    // 更新指標位置
    void UpdatePosition(){
		Vector3 pos = hand.position ;
		pos.y = buttons[id].position.y - 0.22f;
        pos.x = xOffset[id] ;
		hand.position = pos ;
	}
}

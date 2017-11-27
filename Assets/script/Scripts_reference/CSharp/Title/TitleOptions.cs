using UnityEngine;
using System.Collections;

public class TitleOptions : MonoBehaviour {

	public Transform hand ;
	public Transform[] buttons ;
	public float[] xOffset ;
	public World world ;
	public AudioClip moveSound ;
	public AudioClip okSound ;
	int id = 0 ;

	void Start () {
		world = FindObjectOfType<World>() ;
		id = 1 ;
		UpdatePosition() ;
	}

	void Update () {
		// 選單選擇
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			id -- ;
			id = Mathf.Clamp(id,0 ,2) ;
			world.sound.PlaySE(moveSound) ;
			UpdatePosition() ;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			id ++ ;
			id = Mathf.Clamp(id,0 ,2) ;
			world.sound.PlaySE(moveSound) ;
			UpdatePosition() ;
		}
        //確定

        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (id)
            {
                // new
                case 0:
                    Game.screen().FadeAndGo("Map");
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
            world.sound.PlaySE(okSound);
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

using UnityEngine;
using System.Collections;

public class CreateTower : MonoBehaviour {

    public Ray distance;
    public RaycastHit hit;
    public GameObject mTower;
    bool isCreate = false;

    public GUIText loseTxt;
    public GUIText scoreTxt;
    public float score;
	// Use this for initialization
	void Start () {
        score = 10;
        loseTxt.enabled = false;
	}
    /*
    Rect AutoFit(Rect rect)
    {
        float w = Screen.width / 1024;
        float h = Screen.height / 768;
        return new Rect(rect.x * w, rect.y * h, rect.width * w, rect.height * h);
    }*/
	// Update is called once per frame
	void Update () 
    {
        distance = camera.ScreenPointToRay(Input.mousePosition);
        if (isCreate == true)
        {
            if (Physics.Raycast(distance, out hit))
            {
                if (hit.collider.tag != "path")
                {
                    {   //getMouseDown(x) :x=0,left button;1,right button;2,middle button)
                        if (Input.GetMouseButtonDown(0) && hit.collider.name != "Tower(Clone)")
                        {
                            Object.Instantiate(mTower, hit.point + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                            isCreate = false;
                            Debug.Log(hit.point );
                            Debug.Log(hit.collider.name);
                        }
                    }
                }
            }
        }
        UpdateScore();
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,64,64),"点击这里"))
            isCreate = true;
        if (isCreate == true)
        {
            GUI.Button(new Rect(Input.mousePosition.x - 32, Screen.height - Input.mousePosition.y - 32, 64, 64), "这里是模型");
            Debug.Log("Click");
        }
	}

    void UpdateScore()
    {
        
        scoreTxt.text = "Left life:"+score.ToString();
        if (score < 0)
        {
            scoreTxt.enabled = false;
            loseTxt.enabled = true;
        }
    }
}


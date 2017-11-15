using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.script;

public class EventChecker : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(Setting.Scene.Start, LoadSceneMode.Single);
        }
    }
}

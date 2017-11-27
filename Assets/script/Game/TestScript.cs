using UnityEngine;
using System.Collections;
using Game;
using Game.Setting;

public class TestScript : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
        
	}

	// Update is called once per frame
	void Update()
	{
        GameCore.GetSystem<DynamicSceneLoader>().LoadToScene(Setting.Scene.Game);
	}
}

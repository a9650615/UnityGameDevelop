using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour {

    public GameObject Bullet;
    private GameObject BulletClone;

    public float time = 0;
    private float BulletInterval;


	// Use this for initialization
	void Start () {
        BulletInterval = 0.5f;	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && time > BulletInterval)////(2)
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            BulletClone = (GameObject)Instantiate(Bullet, pos, rot);////(3)
            UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(BulletClone, "Assets/script/Game/BulletCreate.cs (27,13)", "BulletState");////(4)
            time = 0;
        }
    }
}


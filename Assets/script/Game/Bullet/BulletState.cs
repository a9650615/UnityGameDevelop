using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour {

	static public int BulletAtk;
    private float BulletSpeed;

    void Start()
    {
        BulletSpeed = 0.25f;
        BulletAtk = 2;
    }

    void Update()
    {
        transform.Translate(0, BulletSpeed, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialCameraRange : MonoBehaviour {

	void Start () {
		GameObject.Find("CamRange").transform.position = transform.position ;
	}
}

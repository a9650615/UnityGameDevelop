﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrap : MonoBehaviour {

	public void Drop(){
        GetComponent<Animation>().Play() ;
    }
}

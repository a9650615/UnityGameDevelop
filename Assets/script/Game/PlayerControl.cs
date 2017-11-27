using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // 該方法接收 a 點與 b 點, a 點為物件位置, b 點為目標位置
    public double GetAngle(Vector2 a, Vector2 b)
    {
        // 這邊需要過濾掉位置相同的問題
        if (a.x == b.x && a.y >= b.y) return 0;

        b -= a;
        double angle = System.Math.Acos(-b.y / b.magnitude) * (180 / Math.PI);

        return (b.x < 0 ? -angle : angle);
    }

    public string GetDirection(double angle)
    {
        if (angle > -22.5 && angle < 22.5) //down
        {
            return "down";
        }
        else if (angle >22.5 && angle <67.5)
        {
            return "right-down";
        }
        else if (angle > 67.5 && angle < 112.5)
        {
            return "right";
        }
        else if (angle > 112.5 && angle < 157.5)
        {
            return "right-up";
        }
        else if (angle < -22.5 && angle > -67.5)
        {
            return "left-down";
        }
        else if (angle < -67.5 && angle > -112.5)
        {
            return "left";
        }
        else if (angle < -112.5 && angle > -157.5)
        {
            return "left-up";
        }
        else if ((angle < -157.5 && angle > -180) || (angle >157.5 && angle < 180)) 
        {
            return "up";
        }

        return "error";
    }

    // Update is called once per frame
    void Update () {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition).normalized;

        // set vector of transform directly
        GameObject.Find("Player").GetComponent<Transform>().up = direction;
        Vector2 screenCenter;
        screenCenter.x = Screen.width / 2;
        screenCenter.y = Screen.height / 2;
        //Debug.Log(GetDirection(GetAngle(screenCenter, (Vector2)Input.mousePosition)));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerControl : MonoBehaviour 
{
    public GameObject _bullet;
    public float _moveSpeed = 10.5f;
    private Vector2 direction;
    private GameObject _player;
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player");
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

    //public string GetDirection(double angle)
    //{
    //    if (angle > -22.5 && angle < 22.5) //down
    //    {
    //        return "down";
    //    }
    //    else if (angle >22.5 && angle <67.5)
    //    {
    //        return "right-down";
    //    }
    //    else if (angle > 67.5 && angle < 112.5)
    //    {
    //        return "right";
    //    }
    //    else if (angle > 112.5 && angle < 157.5)
    //    {
    //        return "right-up";
    //    }
    //    else if (angle < -22.5 && angle > -67.5)
    //    {
    //        return "left-down";
    //    }
    //    else if (angle < -67.5 && angle > -112.5)
    //    {
    //        return "left";
    //    }
    //    else if (angle < -112.5 && angle > -157.5)
    //    {
    //        return "left-up";
    //    }
    //    else if ((angle < -157.5 && angle > -180) || (angle >157.5 && angle < 180)) 
    //    {
    //        return "up";
    //    }

    //    return "error";
    //}

    // Update is called once per frame
    void Update () {
        //Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        // get direction you want to point at
        direction = (mousePos).normalized;

        // set vector of transform directly
        GameObject.Find("Player").GetComponent<Transform>().up = direction;
        Vector2 screenCenter;
        screenCenter.x = Screen.width / 2;
        screenCenter.y = Screen.height / 2;
        //Debug.Log(GetDirection(GetAngle(screenCenter, (Vector2)Input.mousePosition)));

        CheckIsClick();
        MoveCheck();
        CameraMove();

        GameCore.GetSystem<EventDetect>().Update();
    }

    void CheckIsClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameCore.GetSystem<PlayerShotting>().Shooting();
			//GameObject childGameObject = Instantiate(_bullet);
            //childGameObject.SetActive(true);
            //childGameObject.GetComponent<Transform>().position = GameObject.Find("Weapon").transform.position;
            //childGameObject.GetComponent<Transform>().up = GameObject.Find("Player").GetComponent<Transform>().up;
            //childGameObject.GetComponent<Transform>().Rotate(new Vector3(0f, 0f, 90f));
            //childGameObject.GetComponent<Rigidbody2D>().AddForce(GameObject.Find("Player").GetComponent<Transform>().up * 0.05f);
        }
    }

    void MoveCheck()
    {
        Rigidbody2D move = _player.GetComponent<Rigidbody2D>();;
        if (Input.GetKeyDown(KeyCode.W))
        {
            move.AddForce(Vector2.up * _moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            move.AddForce(Vector2.left * _moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            move.AddForce(Vector2.down * _moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            move.AddForce(Vector2.right * _moveSpeed);
        }
    }

    void CameraMove()
    {
        GameObject.Find("Main Camera").GetComponent<Transform>().position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }
}

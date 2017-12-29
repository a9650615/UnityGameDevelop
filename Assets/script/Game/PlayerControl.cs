using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Game.Setting;
using Game.Entity;

public class PlayerControl : Animal 
{
    public string objName = "Player";
    public float _buildLoadTime = 10;
    private float _buildLoading;
    private GameObject _hpBar;
    private GameObject _buildBar;

	// Use this for initialization
	void Start () {
        mainObject = GameObject.Find(objName);
        _moveSpeed = 10.5f;
        _hpBar = GameObject.Find("HpMask");
        _buildBar = GameObject.Find("BuildWaitBar");
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

    void UpdateHud()
    {
        float maxHp = mainObject.GetComponent<Player>().maxHp;
        float hp = mainObject.GetComponent<Player>().hp;
        _hpBar.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(hp/maxHp*((RectTransform)_hpBar.transform).rect.width, ((RectTransform)_hpBar.transform).rect.height);
        _buildBar.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(_buildLoading/_buildLoadTime * ((RectTransform)_buildBar.transform).rect.width, ((RectTransform)_buildBar.transform).rect.height);
    }

    // Update is called once per frame
    void Update () {
        //Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        // get direction you want to point at
        _direction = (mousePos).normalized;

        // set vector of transform directly
        GameObject.Find(objName).GetComponent<Transform>().up = _direction;

        CheckIsClick();
        MoveCheck();
        CameraMove();

        GameCore.GetSystem<EventDetect>().Update();
        UpdateHud();

        if (_buildLoading < _buildLoadTime)
            _buildLoading += Time.deltaTime;
    }

    void CheckIsClick()
    {
        if (GameCore.GetSystem<EventDetect>().CheckMouseIsPress(Key.Left_MouseKey))
        {
            GameCore.GetSystem<PlayerShotting>().Shooting();
        }
        if (_buildLoading >= _buildLoadTime && GameCore.GetSystem<EventDetect>().CheckMouseIsPress(Key.Right_MouseKey))
        {
            GameObject tower = GameCore.GetSystem<ResourceSystem>().GetResource("tower");
            tower = GameCore.GetSystem<CreatorSystem>().AppendToWorld(tower, "tower");
            tower.AddComponent<Tower>();
            tower.transform.position = mainObject.transform.position;
            tower.GetComponent<Tower>().attackTime = 2;
            _buildLoading = 0;
        }
    }

    void MoveCheck()
    {
        Rigidbody2D move = mainObject.GetComponent<Rigidbody2D>();;
        Vector2 direct = Vector2.zero;
        EventDetect e = GameCore.GetSystem<EventDetect>();
        if (e.CheckKeyPress(Key.Up))
        {
            direct += Vector2.up;
        }
        if (e.CheckKeyPress(Key.Down))
        {
            direct += Vector2.down;
        }
        if (e.CheckKeyPress(Key.Left))
        {
            direct += Vector2.left;
        }
        if (e.CheckKeyPress(Key.Right))
        {
            direct += Vector2.right;
        }

        move.velocity = direct * _moveSpeed;
    }

    void CameraMove()
    {
        Vector3 specificVector = new Vector3(mainObject.transform.position.x, mainObject.transform.position.y, -1);
        GameObject.Find("Main Camera").GetComponent<Transform>().position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, specificVector, 7f * Time.deltaTime);
    }
}

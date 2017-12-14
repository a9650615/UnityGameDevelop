using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game;
using Game.Setting;
using UnityEngine;

public class EventDetect : IGameSystemMono
{
    public Vector2 direction;
    public Vector2 offsetPosition;

    public override void StartGameSystem()
    {
    }

    public override void DestoryGameSystem()
    {
    }

    public void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        offsetPosition = mousePos;
        direction = (mousePos).normalized;
    }

    public bool CheckIsClick(int keyCode)
    {
        return Input.GetMouseButtonDown(keyCode);
    }

    public string CheckKeyEvent()
    {
        if (Input.GetKeyDown(KeySetting.Up))
        {
            return "Up";
        }
        else if (Input.GetKeyDown(KeySetting.Down))
        {
            return "Down";
        }
        else if (Input.GetKeyDown(KeySetting.Left))
        {
            return "Left";
        }
        else if (Input.GetKeyDown(KeySetting.Right))
        {
            return "Right";
        }
        return null;
    }
}
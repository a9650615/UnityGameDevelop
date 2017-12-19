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

        CheckKeyEvent();
    }

    public bool CheckMouseIsPress(string key)
    {
        if (Key.MouseKey.ContainsKey(key))
        {
            return Key.MouseKey[key].pressed;
        }
        return false;
    }

    public bool CheckKeyPress(string key)
    {
        if (Key.KeySetting.ContainsKey(key))
        {
            return Key.KeySetting[key].pressed;
        }
        return false;
    }

    public void CheckKeyEvent()
    {
        /* KeyBoard */
        foreach(KeyValuePair<string, KeyState> item in Key.KeySetting)
        {
            if (Input.GetKeyDown(item.Value.keyCode))
            {
                item.Value.Press();
            }
            else if (Input.GetKeyUp(item.Value.keyCode))
            {
                item.Value.Release();
            }
        }
        /* Mouse */
        foreach (KeyValuePair<string, MouseKeyState> item in Key.MouseKey)
        {
            if (Input.GetMouseButtonDown(item.Value.keyCode))
            {
                item.Value.Press();
            }
            else if (Input.GetMouseButtonUp(item.Value.keyCode))
            {
                item.Value.Release();
            }
        }
    }
}
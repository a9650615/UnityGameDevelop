using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Setting
{

    public static class Setting
    {
        public static class Scene
        {
            public const string Start = "Assets/scene/Start.unity";
            public const string Title = "Assets/scene/Title.unity";
            public const string GameLoader = "Assets/scene/GameLoaderScene.unity";
            public const string Game = "Assets/scene/TestGame.unity";
        }
    }

    public class KeyState 
    {
        public bool pressed = false;
        public KeyCode keyCode;
        public KeyState(KeyCode code)
        {
            keyCode = code;
        }
        public void Press()
        {
            pressed = true;
        }
        public void Release()
        {
            pressed = false;            
        }
    }

    public class MouseKeyState
    {
        public bool pressed = false;
        public int keyCode;
        public MouseKeyState(int code)
        {
            keyCode = code;
        }
        public void Press()
        {
            pressed = true;
        }
        public void Release()
        {
            pressed = false;
        }
    }

    public static class Key
    {
		public static string Up = "UP";
		public static string Down = "DOWN";
		public static string Left = "LEFT";
		public static string Right = "RIGHT";

        public static string Left_MouseKey = "LEFT_MOUSEKEY";
        public static string Right_MouseKey = "RIGHT_MOUSEKEY";

        public static Dictionary<string, KeyState> KeySetting = new Dictionary<string, KeyState>()
        {
            {Up, new KeyState(KeyCode.W)},
            {Down, new KeyState(KeyCode.S)},
            {Left, new KeyState(KeyCode.A)},
            {Right, new KeyState(KeyCode.D)},
        };

        public static Dictionary<string, MouseKeyState> MouseKey = new Dictionary<string, MouseKeyState>()
        {
            {Left_MouseKey, new MouseKeyState(0)},
            {Right_MouseKey, new MouseKeyState(1)}
        };
    }
}

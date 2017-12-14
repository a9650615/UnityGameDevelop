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

    public static class KeySetting
    {
        public static KeyCode Up = KeyCode.W;
        public static KeyCode Down = KeyCode.S;
        public static KeyCode Left = KeyCode.A;
        public static KeyCode Right = KeyCode.D;
    }
}

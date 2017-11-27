using UnityEngine;
using System.Collections;
using Game.SplashScreen;
using Game.Setting;


public class GotoMenuScene : MonoBehaviour
{
    private FadeInOut _fadeAndGo;

    void GoTo()
	{
        _fadeAndGo = FindObjectOfType<FadeInOut>();
        _fadeAndGo.FadeAndGo(Setting.Scene.Title);
	}
}
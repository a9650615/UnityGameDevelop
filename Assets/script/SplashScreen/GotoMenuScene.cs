using UnityEngine;
using System.Collections;
using Assets.script.SplashScreen;
using Assets.script;


public class GotoMenuScene : MonoBehaviour
{
    private FadeInOut _fadeAndGo;

    void GoTo()
	{
        _fadeAndGo = FindObjectOfType<FadeInOut>();
        _fadeAndGo.FadeAndGo(Setting.Scene.Title);
	}
}
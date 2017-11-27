using UnityEngine;
using System.Collections;
using Game;
using UnityEngine.SceneManagement;

public class DynamicSceneLoader : IGameSystemMono
{
    public override void StartGameSystem()
    {
        Debug.Log("Dynamic~~");
    }

    public override void DestoryGameSystem()
    {

    }

    public void LoadToScene(string path)
    {
        SceneManager.LoadScene(path);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour {
    public string map ;
    
    void Awake(){
        SceneManager.LoadScene(map, LoadSceneMode.Additive) ;
    }
}

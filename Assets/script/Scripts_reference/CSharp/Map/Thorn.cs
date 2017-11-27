using System.Collections;
using UnityEngine;

public class Thorn : MonoBehaviour {

    public float delay = 1 ;
    
    IEnumerator Start(){
        yield return new WaitForSeconds(delay) ;
        GetComponent<Animation>().Play() ;
    }
}

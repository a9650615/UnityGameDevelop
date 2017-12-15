using UnityEngine;
using System.Collections;

public class MoveMonster : MonoBehaviour {

    public Transform wayPoint;//[]wayPoint;
    public float life = 100;
    public float speed = 200;
    
    Vector3 currentWayPoint;
    CharacterController mPlayer;
    Vector3 dir;
    int wayPointSub = 1;

	// Use this for initialization
	void Start () 
    {
        mPlayer = gameObject.GetComponent<CharacterController>();
        //currentWayPoint = wayPoint[0].position;
        currentWayPoint = wayPoint.GetChild(0).position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mPlayer.SimpleMove(dir * speed * Time.deltaTime);
        if (Vector3.Distance(currentWayPoint, transform.position) < 0.1f) 
        {
            SwitchWay();
        }
        else
        {
            dir = (currentWayPoint -transform.position).normalized;
        }

        if (Vector3.Distance(wayPoint.GetChild(1).position, transform.position) < 1.0f)
        {
            Destroy(gameObject);
            GameObject.Find("Main Camera").GetComponent<CreateTower>().score--;
             
            
        }

    }

    void SwitchWay()
    {
        currentWayPoint = wayPoint.GetChild(wayPointSub).position;
        wayPointSub++;
    }
}

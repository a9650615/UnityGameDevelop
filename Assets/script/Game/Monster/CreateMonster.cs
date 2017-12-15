using UnityEngine;
using System.Collections;

public class CreateMonster : MonoBehaviour {

	public GameObject Monster;
	public Transform startp;
	private GameObject MonsterTemp;
    void Start()
    {
        InvokeRepeating("MonsterFactory", 1, 3);
    }
	
	// Update is called once per frame
	void Update () 
    {
    }
    void MonsterFactory()
    {
        for (int i = 0; i < Random.Range(1,5); i++)
        {
            MonsterTemp = Instantiate(Monster, startp.transform.position+new Vector3(i,0,0), Quaternion.identity) as GameObject;
        }
	}
}

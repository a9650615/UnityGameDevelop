using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fire : MonoBehaviour {

    public ParticleEmitter emitter;
    private float gameRate = 1.0f;
    private float nextFireTime;
    private string life = " ";
    List<Collider> Monsters = new List<Collider>();
	// Use this for initialization
	void Start () 
    {	
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (Monsters[i] == null)
                Monsters.Remove(Monsters[i]);
        }
	}

    void OnTriggerEnter(Collider m)
    {
        Monsters.Add(m);
    }
    void OnTriggerStay(Collider m)
    {
        Collider monster = Monsters[0];
        if (monster != null)
        {
            //MoveMonster temp = monster.GetComponent<MoveMonster>();
            transform.LookAt(monster.transform);
            /*if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + gameRate;
                monster.GetComponent<MoveMonster>().life -= 10;
                monster.transform.GetChild(0).GetComponent<TextMesh>().text = life;
                life = "";
                emitter.Emit();
             }*/
            
        }
    }
    void OnTriggerExit(Collider m)
    {
        Monsters.Remove(m);
    }
}

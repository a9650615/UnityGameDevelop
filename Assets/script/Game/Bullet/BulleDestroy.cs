using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCState : MonoBehaviour
{

    private int HP = 5;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet") ////(1)
        {
            Destroy(collider.gameObject);
            HP -= BulletState.BulletAtk;////(2)
        }
    }

    void Update()
    {
        if (HP <= 0)////(3)
            Destroy(gameObject);
    }
}


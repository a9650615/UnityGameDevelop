using UnityEngine;
using System.Collections;

namespace Game.Entity
{
	public class Bullet : MonoBehaviour
	{
        public int attack = 10;
        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "CanCrack" || collision.gameObject.tag == "MapBlock")
            {
                if (collision.gameObject.tag == "CanCrack")
                {
                    Debug.Log(collision.gameObject.GetComponent<CanBeAttack>().BeAttack(attack));
                }
				Destroy(this.gameObject);
            }
        }
    }
}

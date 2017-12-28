using UnityEngine;
using System.Collections;

namespace Game.Entity
{
	public class Bullet : MonoBehaviour
	{
        public int attack = 10;
        public bool isFromTower = false;
        public void OnTriggerStay2D(Collider2D collision)
        {
            if (isFromTower)
            {
                if (collision.gameObject.tag == "Monster")
                {
                    collision.gameObject.GetComponent<CanBeAttack>().BeAttack(attack);
					Destroy(this.gameObject);
                }
            }
            else 
            {
				if (collision.gameObject.tag == "Monster" || collision.gameObject.tag == "CanCrack" || collision.gameObject.tag == "MapBlock")
				{
					if (collision.gameObject.tag == "Monster")
					{
						collision.gameObject.GetComponent<CanBeAttack>().BeAttack(attack);
					}
					Destroy(this.gameObject);
				}
            }
        }
    }
}

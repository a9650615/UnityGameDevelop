using UnityEngine;
using System.Collections;

namespace Game.Entity
{
	public class Bullet : MonoBehaviour
	{
        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "CanCrack" || collision.gameObject.tag == "MapBlock")
            {
				Destroy(this.gameObject);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

namespace Game.Entity
{
	public class Bullet : MonoBehaviour
	{
        public void OnTriggerStay2D(Collider2D collision)
        {
            Destroy(this.gameObject);
        }
    }
}

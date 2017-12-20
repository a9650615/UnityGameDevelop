using UnityEngine;
using System.Collections;
using Game;

namespace Game.Entity
{
    public class Bar
    {
        public GameObject gameObject;
        public Vector3 offset = new Vector3(-5, 70, 0);
		private GameObject _parent;

        public Bar(GameObject parent)
        {
            _parent = parent;
            GameObject bar = GameCore.GetSystem<ResourceSystem>().GetResource("Bar");
            gameObject = GameCore.GetSystem<CreatorSystem>().AppendGameObjectToCanvas(bar, "TowerHp");
        }

        public void Update()
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(_parent.transform.position) + offset;
        }
    }
}

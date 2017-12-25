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
        private RectTransform objReactTran;
        private float defaultWidth;

        public Bar(GameObject parent)
        {
            _parent = parent;
            GameObject bar = GameCore.GetSystem<ResourceSystem>().GetResource("Bar");
            gameObject = GameCore.GetSystem<CreatorSystem>().AppendGameObjectToCanvas(bar, "TowerHp");
            objReactTran = gameObject.transform.GetChild(0).transform as RectTransform;
            defaultWidth = objReactTran.sizeDelta.x;
        }

        public void Update(float hp, float maxHp)
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(_parent.transform.position) + offset;
            objReactTran.sizeDelta = new Vector2((hp/maxHp) * defaultWidth, objReactTran.sizeDelta.y);
        }

        public void Remove()
        {
            GameCore.GetSystem<CreatorSystem>().RemoveByGameObject(gameObject, "TowerHp");
        }
    }
}

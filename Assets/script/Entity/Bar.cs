using UnityEngine;
using System.Collections;
using Game;

namespace Game.Entity
{
    public class Bar
    {
        public GameObject gameObject;
        private Vector3 _offset;
		private GameObject _parent;
        private RectTransform objReactTran;
        private float defaultWidth;
        private string _typeName;

        public Bar(GameObject parent, Vector2 offset, string type)
        {
            _parent = parent;
            _offset = offset;
            _typeName = type;
            GameObject bar = GameCore.GetSystem<ResourceSystem>().GetResource("Bar");
            gameObject = GameCore.GetSystem<CreatorSystem>().AppendGameObjectToCanvas(bar, _typeName+"Hp");
            objReactTran = gameObject.transform.GetChild(0).transform as RectTransform;
            defaultWidth = objReactTran.sizeDelta.x;
        }

        public void Update(float hp, float maxHp)
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(_parent.transform.position) + _offset;
            objReactTran.sizeDelta = new Vector2((hp/maxHp) * defaultWidth, objReactTran.sizeDelta.y);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Remove()
        {
            GameCore.GetSystem<CreatorSystem>().RemoveByGameObject(gameObject, _typeName+"Hp");
        }
    }
}

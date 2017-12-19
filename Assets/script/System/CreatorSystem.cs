using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Game;

class CreatorSystem : IGameSystemMono
{
    private Dictionary<string, List<GameObject>> _allResource = new Dictionary<string, List<GameObject>>();
    private GameObject _container;

    public GameObject AppendGameObject(GameObject obj, string type) {
        GameObject copy = Instantiate(obj);
        copy.transform.parent = _container.transform;
        if (!_allResource.ContainsKey(type)) 
        {    
            _allResource.Add(type, new List<GameObject>());
        }
        _allResource[type].Add(copy);
        return copy;
    }

    public List<GameObject> GetTypeList(string type)
    {
        return _allResource[type];
    }

    public override void StartGameSystem()
    {
        /* Create base gameObject */
        _container = new GameObject();
        _container.name = "Creator";
    }

    public override void DestoryGameSystem()
    {
    }
}

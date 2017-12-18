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
        if (!_allResource.ContainsKey(type)) 
        {    
            _allResource.Add(type, new List<GameObject>());
        }
        _allResource[type].Add(copy);
        return copy;
    }

    public override void StartGameSystem()
    {
        /* Create base gameObject */
        _container = Instantiate(new GameObject());
    }

    public override void DestoryGameSystem()
    {
    }
}

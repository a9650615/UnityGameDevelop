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
    private const string CANVAS = "Canvas";

    public GameObject AppendGameObject(GameObject obj, string type) {
        GameObject copy = Append(obj, type);
        copy.transform.parent = _container.transform;
        return copy;
    }

    public GameObject AppendGameObjectToCanvas(GameObject obj, string type)
    {
        GameObject copy = Append(obj, type);
        copy.transform.parent = GameObject.Find(CANVAS).transform;
        return copy;
    }

    public void RemoveByGameObject(GameObject obj, string type)
	{
        int index = _allResource[type].FindIndex(gameObj => gameObj.GetInstanceID() == obj.GetInstanceID());
        Debug.Log(index);
        Destroy(_allResource[type][index]);
        _allResource[type].RemoveAt(index);
	}

    private GameObject Append(GameObject obj, string type)
    {
        GameObject copy = Instantiate(obj);

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

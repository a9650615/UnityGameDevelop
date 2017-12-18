using System.Collections.Generic;
using Game;
using UnityEngine;

public class ResourceSystem : IGameSystemMono
{
    public GameObject resouece;
    private Dictionary<string, GameObject> _allResource = new Dictionary<string, GameObject>();

    public GameObject GetResource(string name)
    {
        return _allResource[name];
    }

    public override void StartGameSystem()
    {
        Transform allResource = resouece.transform;
		foreach (Transform res in allResource)
		{
			_allResource.Add(res.name, res.gameObject);
		}
    }

    public override void DestoryGameSystem()
    {
    }
}

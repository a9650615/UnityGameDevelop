using UnityEngine;
using System.Collections;

public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}

public class OnTheWorld : MonoBehaviour
{
    void LateUpdate()
    {
        if (gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
			Debug.Log("Update");
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)((float)(Camera.main.WorldToScreenPoint(gameObject.GetComponent<SpriteRenderer>().bounds.min).y - Screen.height / 2)> 0? -1: 1);
        }
    }
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
			
	}
}

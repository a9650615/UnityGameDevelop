using UnityEngine;
using System.Collections;
using Game;
using Game.Entity;

public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}

public class Tower : CanBeAttack
{
    bool firstLoad = false;
    private Bar _bar;

    void LateUpdate()
    {
        if (gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = ((float)(Camera.main.WorldToScreenPoint(gameObject.GetComponent<SpriteRenderer>().bounds.min).y - Screen.height / 2) > 0 ? "BackGround" : "FrontGround");
            //gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)((float)(Camera.main.WorldToScreenPoint(gameObject.GetComponent<SpriteRenderer>().bounds.min).y - Screen.height / 2)> 0? -2: 2);
            _bar.Update(hp, maxHp);
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
            _bar.Remove();
            _bar = null;
        }
    }
	
    public override int BeAttack(int attack)
    {
        return hp = hp - attack;
    }

	// Update is called once per frame
	void Update()
	{
        if (!firstLoad)
        {
            _bar = new Bar(gameObject);
            firstLoad = true;
        }
	}
}

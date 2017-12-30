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

public class CanBeAttack : MonoBehaviour
{
    public int hp = 100;
	public int maxHp = 100;
	bool firstLoad = false;
    protected Bar _bar;

    public virtual string GetName()
    {
        return "CanBeAttack";
    }

    public virtual Vector2 GetOffset()
    {
        return new Vector2();
    }

	public virtual int BeAttack(int attack)
	{
		return 0;
	}

    public virtual void Start()
    {
        gameObject.tag = "CanCrack";
        hp = maxHp;
    }

    void LateUpdate()
    {
        if (!firstLoad&&GetName() != "Player")
        {
            _bar = new Bar(gameObject, GetOffset(), GetName());
            firstLoad = true;
        }

        if (gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = ((float)(Camera.main.WorldToScreenPoint(gameObject.GetComponent<SpriteRenderer>().bounds.min).y - Screen.height / 2) > 0 ? "BackGround" : "FrontGround");
            //gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)((float)(Camera.main.WorldToScreenPoint(gameObject.GetComponent<SpriteRenderer>().bounds.min).y - Screen.height / 2)> 0? -2: 2);
            _bar.Update(hp, maxHp);
            _bar.Show();
        }
        else
        {
            _bar.Hide();
        }

        if (hp <= 0 && GetName() != "Player")
        {
            GameCore.GetSystem<CreatorSystem>().RemoveByInstantId(GetName(), gameObject);
            Destroy(gameObject);
            _bar.Remove();
            _bar = null;
        }
    }
}

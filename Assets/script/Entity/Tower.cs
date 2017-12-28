using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game;
using Game.Entity;

public class Tower : CanBeAttack
{
    public float attackTime = 1f;
    public float counter = 0;
    public string towerType = "mg";
    private List<Sprite> _sprites;

    public void ChangeSprite(float angle)
    {
        float forward = -1;
        if (angle != -1)
        if (angle >= 337.5 || angle < 22.5f)
        {
            forward = 4;
        }
        else if (angle < 67.5f)
        {
            forward = 5;
        }
        else if (angle < 112.5f)
        {
            forward = 6;
        }
        else if (angle < 157.5f)
        {
            forward = 7;
        }
        else if (angle < 202.5f)
        {
            forward = 0;
        }
        else if (angle < 247.5f)
        {
            forward = 1;
        }
        else if (angle < 292.5f)
        {
            forward = 2;
        }
        else if (angle < 337.5f)
        {
            forward = 3;
        }

        if (forward != -1)
        {
			GetComponent<Animator>().Play("towerMg", -1, forward/8);
			GetComponent<Animator>().speed = 0;
        }
        else
        {
            GetComponent<Animator>().speed = 1;
        }
    }

    public override string GetName()
    {
        return "Tower";
    }

    public override Vector2 GetOffset()
    {
        return new Vector2(-5, 70);
    }

    public override int BeAttack(int attack)
    {
        return hp = hp - attack;
    }

	// Update is called once per frame
	void Update()
	{
        float rotate;
        counter += Time.deltaTime * 10;
        if (counter > attackTime)
        {
            rotate = GameCore.GetSystem<TowerShotting>().Shotting(gameObject);
            //Debug.Log(rotate);
            ChangeSprite(rotate);
            counter = 0;
        }
	}
}

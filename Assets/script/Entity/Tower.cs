using UnityEngine;
using System.Collections;
using Game;
using Game.Entity;

public class Tower : CanBeAttack
{
    public float attackTime = 0.1f;
    public float counter = 0;

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
        counter += Time.deltaTime * 10;
        if (counter > attackTime)
        {
			GameCore.GetSystem<TowerShotting>().Shotting(gameObject);
            counter = 0;
        }
	}
}

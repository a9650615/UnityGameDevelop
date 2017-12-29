using UnityEngine;
using System.Collections;
using Game.Entity;

public class Player : CanBeAttack
{
	public string GetName()
    {
        return "Player";
    }

    public override int BeAttack(int attack)
    {
        hp = hp - attack;
        hp = hp<=0? 1: hp;
        return hp;
    }

	// Update is called once per frame
	void Update()
	{
			
	}
}

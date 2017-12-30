using UnityEngine;
using System.Collections;
using Game.Entity;
using Game;
using Game.Setting;

public class Player : CanBeAttack
{
	public string GetName()
    {
        return "Player";
    }

    public override int BeAttack(int attack)
    {
        hp = hp - attack;
        //hp = hp<=0? 1: hp;
        if (hp < 0)
            GameCore.GetSystem<DynamicSceneLoader>().LoadToScene(Setting.Scene.Title);
        return hp;
    }

	// Update is called once per frame
	void Update()
	{
			
	}
}

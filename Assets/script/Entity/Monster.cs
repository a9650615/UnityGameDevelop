using UnityEngine;
using System.Collections;

public class Monster : CanBeAttack
{
    public override string GetName()
    {
        return "Monster";
    }

    public override Vector2 GetOffset()
    {
        return new Vector2(12, 30);
    }

    public override int BeAttack(int attack)
    {
        return hp = hp - attack;
    }

	// Update is called once per frame
	void Update()
	{
			
	}
}

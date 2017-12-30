using UnityEngine;
using System.Collections;
using Game.Setting;

public class LevelSelecter : MonoBehaviour
{
	public void SelectSimple()
    {
        LevelSetting.MonsterHp = 500;
        LevelSetting.MonsterAttackTime = 3;
        LevelSetting.MonsterSpawnTime = 5;
        LevelSetting.MonsterMoveSpeed = 3;
        LevelSetting.MonsterViewRange = 10;
        LevelSetting.MonsterAttackRange = 1;
        LevelSetting.MonstarAttack = 4;
        LevelSetting.updateTargetTime = 5;
        LevelSetting.MonstarAttackTime = 2;
        LevelSetting.MaxMonster = 30;
        Back();
    }

    public void SelectMedium()
    {
        LevelSetting.MonsterHp = 1000;
        LevelSetting.MonsterAttackTime = 2;
        LevelSetting.MonsterSpawnTime = 3;
        LevelSetting.MonsterMoveSpeed = 6;
        LevelSetting.MonsterViewRange = 15;
        LevelSetting.MonsterAttackRange = 1.2f;
        LevelSetting.MonstarAttack = 7;
        LevelSetting.MonstarAttackTime = 1;
        LevelSetting.updateTargetTime = 3;
        LevelSetting.MaxMonster = 40;
        Back();
    }

    public void SelectHard() //very hard
    {
        LevelSetting.MonsterHp = 2500;
        LevelSetting.MonsterAttackTime = 0.5f;
        LevelSetting.MonsterSpawnTime = 0.5f;
        LevelSetting.MonsterMoveSpeed = 10;
        LevelSetting.MonsterViewRange = 15;
        LevelSetting.MonsterAttackRange = 2f;
        LevelSetting.MonstarAttack = 15;
        LevelSetting.updateTargetTime = 2;
        LevelSetting.MonstarAttackTime = .5f;
        LevelSetting.MaxMonster = 120;
        Back();
    }

    public void Back()
    {
        GameObject.Find("GameTypeSelect").SetActive(false);
        GameObject.Find("Select").SetActive(true);
    }
}

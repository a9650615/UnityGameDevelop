using UnityEngine;
using System.Collections;
using Game.Setting;

public class LevelSelecter : MonoBehaviour
{
	public void SelectSimple()
    {
        LevelSetting.MonsterHp = 10;
        LevelSetting.MonsterAttackTime = 3;
        LevelSetting.MonsterSpawnTime = 3;
        Back();
    }

    public void SelectMedium()
    {
        LevelSetting.MonsterHp = 100;
        LevelSetting.MonsterAttackTime = 2;
        LevelSetting.MonsterSpawnTime = 2;
        Back();
    }

    public void SelectHard()
    {
        LevelSetting.MonsterHp = 1000;
        LevelSetting.MonsterAttackTime = 1;
        LevelSetting.MonsterSpawnTime = 1;
        Back();
    }

    public void Back()
    {
        GameObject.Find("GameTypeSelect").SetActive(false);
        GameObject.Find("Select").SetActive(true);
    }
}

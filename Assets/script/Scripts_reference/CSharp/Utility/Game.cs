using UnityEngine;
using System.Collections;

public static class Game {

	public static SaveData sav = new SaveData() ;
	public static bool pause = false ;
	
	public static void Reset(){
		sav = new SaveData() ;
	}
	// 取得screen
	public static ScreenUI screen(){
		return UnityEngine.Object.FindObjectOfType<ScreenUI>() ;
	}
	// 快速取得角色
	public static Transform player(){
		return GameObject.FindWithTag("Player").transform ;
	}
}

public class SaveData{
	public float maxHp = 5f ;
	public float hp = 5.0f ;
	public float maxSp  = 500f;
	public float sp = 500f ;
	public int money = 0 ;
	public float skillCost = 100f ;
	public float regSpeed = 12f ;
	public float ammoCost = 5f ;
  
	public void GainMoney(int i){
		money = (int)Mathf.Clamp(money+i, 0, 999f) ;
	}
  
	public void CostSP(float s){
		sp = Mathf.Clamp(sp-s, 0, maxSp) ;
	}
  
	public void RegenSP(float f){
		CostSP(-regSpeed*f) ;
	}
  
	public bool CanUseSkill(){
		return sp >= skillCost ;
	}
  
	public bool HasAmmo(){
		return sp >= ammoCost ;
	}
  
	public float Damage(float dmg){
		hp = Mathf.Clamp(hp-dmg, 0, maxHp) ;
		return hp ;
	}
}

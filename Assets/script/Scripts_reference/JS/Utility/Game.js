#pragma strict

static class Game{
  var sav : SaveData = new SaveData() ;
  // 取得screen
  function screen() : ScreenUI{
    return UnityEngine.Object.FindObjectOfType.<ScreenUI>() ;
  }
}

class SaveData{
  var maxHp : float = 5 ;
  var hp : float = 1.5 ;
  var maxSp : float = 500 ;
  var sp : float = 500 ;
  var money : int = 0 ;
  var skillCost : float = 100 ;
  var regSpeed : float = 12 ;
  var ammoCost : float = 5 ;
  
  function GainMoney(i:int){
    money = Mathf.Clamp(money+i, 0, 999) ;
  }
  
  function CostSP(s:float){
    sp = Mathf.Clamp(sp-s, 0, maxSp) ;
  }
  
  function RegenSP(f:float){
    CostSP(-regSpeed*f) ;
  }
  
  function CanUseSkill() : boolean{
    return sp >= skillCost ;
  }
  
  function HasAmmo() : boolean{
    return sp >= ammoCost ;
  }
}

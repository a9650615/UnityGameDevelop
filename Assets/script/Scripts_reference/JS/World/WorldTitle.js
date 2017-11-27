#pragma strict

class WorldTitle extends World{
  var btns : GameObject ;
  var anyKeyText : GameObject ;
  
  function Update(){
    // 按下任意鍵
    if(Input.anyKey){
      btns.SetActive(true) ;
      anyKeyText.SetActive(false) ;
    }
  }
}

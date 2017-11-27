#pragma strict
var hearts : Transform ;
var heartImage : Sprite[] ;
var sp : RectTransform ;
var coinText : UI.Text ;
private var coin : int = 0 ;

function Awake(){
  DrawMaxHP() ;
}

function Update(){
  DrawSP() ;
  DrawCoin() ;
}

function DrawMaxHP(){
  for(var i=1 ; i<Game.sav.maxHp ; i++){
    var h : Transform = Instantiate(hearts.GetChild(0)) ;
    h.SetParent(hearts, false) ;
    h.name = "h"+(i+1) ;
  }
  DrawHP() ;
}

function DrawHP(){
  var hp : float = Game.sav.hp ;
  for(var img:UI.Image in hearts.GetComponentsInChildren.<UI.Image>()){
    img.sprite = heartImage[0] ;
  }
  
  for(var i=1 ; i<hp ; i++){
    hearts.GetChild(i-1).GetComponent.<UI.Image>().sprite = heartImage[2] ;
  }
  
  if(hp > Mathf.Floor(hp)){
    hearts.GetChild(Mathf.Floor(hp)).GetComponent.<UI.Image>().sprite = heartImage[1] ;
  }
}

function DrawSP(){
  var s = Game.sav.sp ;
  sp.sizeDelta.x = Mathf.Lerp(sp.sizeDelta.x, s, 0.12) ;
}

function DrawCoin(){
  if(Game.sav.money > coin){
    coinText.GetComponentInParent.<Animation>().Play() ;
  }
  coin = Game.sav.money ;
  
  coinText.text = "x " + Game.sav.money ;
}


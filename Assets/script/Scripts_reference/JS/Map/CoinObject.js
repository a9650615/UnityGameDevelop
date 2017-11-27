#pragma strict
var amount : int = 1 ;

function OnTriggerEnter2D(co:Collider2D){
  if(co.tag != "Player"){return;}
  Game.sav.GainMoney(1) ;
  GetComponent.<Animator>().SetTrigger("Eat") ;
  Destroy(this) ;
}


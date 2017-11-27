#pragma strict
private var pl : Transform ;

function Awake(){
  pl = gameObject.FindWithTag("Player").transform ;
}

function Update () {
  transform.position = pl.position + Vector3(-0.7, 2.2, 0) ;
}

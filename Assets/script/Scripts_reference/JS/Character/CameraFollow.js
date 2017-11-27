#pragma strict
private var player : Transform ;
private var bound : Collider ;

function Awake(){
  player = gameObject.FindWithTag("Player").transform ;
  bound = gameObject.Find("CamRange").GetComponent.<Collider>() ;
}

function Update(){
  var offsetY : float = -transform.position.z/Mathf.Pow(3,0.5) ;
  var offsetX : float = offsetY*((Screen.width+0f)/(Screen.height+0f)) ;
  var min : Vector3 = bound.bounds.min ;
  var max : Vector3 = bound.bounds.max ;
  transform.position.x = Mathf.Clamp(player.position.x, min.x+offsetX, max.x-offsetX) ;
  transform.position.y = Mathf.Clamp(player.position.y, min.y+offsetY, max.y-offsetY) ;
}

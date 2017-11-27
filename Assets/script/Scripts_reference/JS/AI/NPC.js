#pragma strict
var pos1 : Vector3 ;
var pos2 : Vector3 ;
var waitTime : Vector2 ;

internal var nav : Navigation2D ;
internal var anim : Animator ;

function Awake(){
  nav = GetComponent.<Navigation2D>() ;
  anim = GetComponent.<Animator>() ;
  pos1 += transform.position ;
  pos2 += transform.position ;
}

function Start(){
  StartCoroutine("Wander") ;
}

function Update(){
  StateMachine() ;
}

function Wander(){
  var point1 : boolean = true ;
  nav.MoveTo(pos1) ;
  
  while(true){
    if(!nav.moving){
      yield WaitForSeconds(Random.Range(waitTime.x, waitTime.y)) ;
      point1 = !point1 ;
      nav.MoveTo(point1 ? pos1 : pos2) ;
    }
    yield WaitForSeconds(Time.deltaTime) ;
  }
}

function StateMachine(){
  anim.SetBool("move", nav.moving) ;
}

//========
// 觸發器
//========
function OnTriggerEnter2D(co:Collider2D){
  if(co.tag != "Player"){return ;}
  co.GetComponent.<Controller>().SpawnButton() ;
}
function OnTriggerExit2D(co:Collider2D){
  if(co.tag != "Player"){return ;}
  co.GetComponent.<Controller>().DestroyButton() ;
}

//=======
// Debug
//=======
function OnDrawGizmosSelected(){
  Gizmos.color = Color.red ;
  Gizmos.DrawWireSphere(transform.position+pos1, 0.2) ;
  Gizmos.DrawWireSphere(transform.position+pos2, 0.2) ;
}

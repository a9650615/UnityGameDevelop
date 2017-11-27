#pragma strict
var speed : float = 23 ;
var stoppingDistance : float = 0.05 ;
internal var targetPos : Vector3 ;
internal var moving : boolean = false ; 
private var body : Rigidbody2D ;

function Awake(){
  body = GetComponent.<Rigidbody2D>() ;
}

function FixedUpdate(){
  var movSpeed : float = Time.fixedDeltaTime*speed*Mathf.Sign(targetPos.x-transform.position.x) ;
  body.velocity.x = moving ?  movSpeed : 0 ;
  
  // 方向判定
  if(body.velocity.x != 0){
    transform.eulerAngles.y = body.velocity.x > 0 ? 0 : 180 ;
  }
  // 到達目標點停止
  if(Mathf.Abs(transform.position.x-targetPos.x) <= stoppingDistance){
    StopMove() ;
  }
}

//======
// 事件
//======
function StartMove(){
  moving = true ;
}

function StopMove(){
  moving = false ;
}

function MoveTo(p:Vector3){
  targetPos = p ;
  StartMove() ;
}

#pragma strict
var speed : float = 140 ;
var jumpHeight : float = 15 ;

var buttonObject : GameObject ;
internal var btn : GameObject ;

internal var isGround : boolean = false ;
internal var body : Rigidbody2D ;
internal var anim : Animator ;
internal var state : AnimatorStateInfo ;
internal var lockMove : boolean = false ;


function Awake(){
  Physics2D.IgnoreLayerCollision(9,10) ;
  // 取得各類元件
  body = GetComponent.<Rigidbody2D>() ;
  anim = GetComponentInChildren.<Animator>() ;
}

function Update(){
  Control() ;
  StateMachine() ;
}

function Control(){
  var upKey:boolean = Input.GetKeyUp(KeyCode.RightArrow) ||
  Input.GetKeyUp(KeyCode.LeftArrow) ;

  if(Input.GetKey(KeyCode.RightArrow)){
    Move(1) ;
    Direction(0) ;
  }
  if(Input.GetKey(KeyCode.LeftArrow)){
    Move(-1) ;
    Direction(1) ;
  }
  if(Input.GetKeyDown(KeyCode.Space)){
    Jump() ;
  }
  if(upKey){
    Move(0) ;
  }
}

//=======
// 行動
//=======
function Jump(){
  if(!isGround){return;}
  body.velocity.y = jumpHeight ;
  anim.SetTrigger("Jump") ;
}

function Move(i:int){
  body.velocity.x = i*speed*Time.deltaTime ;
  anim.SetFloat("Move", Mathf.Abs(i)) ;
}

function Direction(i:int){
  transform.eulerAngles = Vector3(0, 180*i, 0) ;
}

//==========
// 動畫
//==========
function StateMachine(){
  anim.SetBool("Ground", isGround) ;
  anim.SetFloat("Y", body.velocity.y) ;
  anim.SetFloat("Ammo", Game.sav.HasAmmo() ? 1:0) ;
  state = anim.GetCurrentAnimatorStateInfo(0) ;
}

//=======
// 碰撞
//=======
function OnCollisionStay2D(col:Collision2D){
  if(col.contacts[0].normal != Vector2.up){return;}
  isGround = true ;
}

function OnCollisionExit2D(col:Collision2D){
  if(col.contacts[0].normal != Vector2.up){return;}
  isGround = false ;
}

//=======
// 事件
//=======
function UseSkill(){
  Game.sav.CostSP(Game.sav.skillCost) ;
}

function Shot(){
  Game.sav.CostSP(Game.sav.ammoCost) ;
}

function SpawnButton(){
  btn = Instantiate(buttonObject) ;
}
function DestroyButton(){
  Destroy(btn) ;
}

#pragma strict

function Message(msg:String){
  transform.root.SendMessage(msg, SendMessageOptions.DontRequireReceiver) ;
}

function MessageFloat(evt : AnimationEvent){
  transform.root.SendMessage(evt.stringParameter, evt.floatParameter, SendMessageOptions.DontRequireReceiver) ;
}

function MessageInt(evt : AnimationEvent){
  transform.root.SendMessage(evt.stringParameter, evt.intParameter, SendMessageOptions.DontRequireReceiver) ;
}

function MessageString(msg:String){
  var str : String[] = msg.Split(","[0]) ;
  transform.root.SendMessage(str[0], str[1], SendMessageOptions.DontRequireReceiver) ;
}

function Die(){
  Destroy(gameObject) ;
}

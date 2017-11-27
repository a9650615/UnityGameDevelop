#pragma strict
internal var sound : SoundManager ;

function Awake(){
  sound = FindObjectOfType.<SoundManager>() ;
}

#pragma strict
var bgm : AudioSource ; // BGM元件
var se : AudioSource ; // SE元件

// 播放音效
function PlaySE(au:AudioClip){
  se.PlayOneShot(au) ;
}

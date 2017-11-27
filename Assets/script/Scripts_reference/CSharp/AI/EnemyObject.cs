using UnityEngine;

public class EnemyObject : Enemy {

    public override void Awake(){
        
    }

    public override void Start(){
        
    }
    
    public override void Damage(float dmg){
        Die() ;
    }
}

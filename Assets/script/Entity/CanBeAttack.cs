using UnityEngine;
using System.Collections;

public class CanBeAttack : MonoBehaviour
{
    public int hp = 100;
 
    public int maxHp = 100;

    public void Start()
    {
        gameObject.tag = "CanCrack";
    }

    public virtual int BeAttack(int attack)
    {
        return 0;
    }
}

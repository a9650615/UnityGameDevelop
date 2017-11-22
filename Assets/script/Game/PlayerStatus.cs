using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
    public struct Weapon
    {
        string name;
        int attack;
        int max_amount;
        int bullet;
        int clip;
        bool isReload;
    }

    public Weapon[] weapon;
    public int selected_weapon;
    public int hp;
    public int max_hp;
    public int level;
    public bool can_hit = true;
}

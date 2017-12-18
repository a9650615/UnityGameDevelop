﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game;
using UnityEngine;

class PlayerShotting : IGameSystemMono
{
    private static CreatorSystem _creatorSystem;
    private GameObject _bullet;

    public void Shooting() 
    {
        GameObject _newBullet = _creatorSystem.AppendGameObject(_bullet, "PlayerAmmo");
        Transform trans = _newBullet.GetComponent<Transform>();
        _newBullet.SetActive(true);
        trans.position = GameObject.Find("Weapon").transform.position;
        trans.up = GameObject.Find("Player").GetComponent<Transform>().up;
        trans.Rotate(new Vector3(0f, 0f, 90f));
        _newBullet.GetComponent<Rigidbody2D>().AddForce(GameObject.Find("Player").GetComponent<Transform>().up * 0.05f);
    }
    
    public override void StartGameSystem()
    {
        _creatorSystem = GameCore.GetSystem<CreatorSystem>();
        _bullet = GameCore.GetSystem<ResourceSystem>().GetResource("PlayerAmmo");
    }

    public override void DestoryGameSystem()
    {
    }
}

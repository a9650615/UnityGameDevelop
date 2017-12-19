using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game;
using UnityEngine;

class PlayerShotting : IGameSystemMono
{
    private static CreatorSystem _creatorSystem;
    private GameObject _bullet;
    const string AmmoName = "PlayerAmmo";
    private const float SHOOT_TIME = 0.15f;
    private float _lastShootTime = 0f;

    public void AutoRemove()
    {
        if (_creatorSystem.GetTypeList(AmmoName).Count() > 20)
        {
            Destroy(_creatorSystem.GetTypeList(AmmoName)[0]);
            _creatorSystem.GetTypeList(AmmoName).RemoveAt(0);
        }
    }

    public void Shooting() 
    {
        if (_lastShootTime > SHOOT_TIME) 
        {
            CreateAmmoAndShoot();
            _lastShootTime = 0;
        }
		_lastShootTime += Time.deltaTime;
    }

    private void CreateAmmoAndShoot()
    {
        GameObject _newBullet = _creatorSystem.AppendGameObject(_bullet, AmmoName);
        Transform trans = _newBullet.GetComponent<Transform>();
        _newBullet.SetActive(true);
        trans.position = GameObject.Find("Weapon").transform.position;
        trans.up = GameObject.Find("Player").GetComponent<Transform>().up;
        trans.Rotate(new Vector3(0f, 0f, 90f));
        _newBullet.GetComponent<Rigidbody2D>().AddForce(GameObject.Find("Player").GetComponent<Transform>().up * 0.05f);
        AutoRemove();        
    }
    
    public override void StartGameSystem()
    {
        _creatorSystem = GameCore.GetSystem<CreatorSystem>();
        _bullet = GameCore.GetSystem<ResourceSystem>().GetResource(AmmoName);
    }

    public override void DestoryGameSystem()
    {
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Game;
using Game.Entity;

public class TowerShotting : IGameSystemMono
{
    private static CreatorSystem _creatorSystem;
    private GameObject _bullet;
    public string AmmoName = "TowerAmmo";
    private GameObject _gameObject;

    public override void StartGameSystem()
    {
        _creatorSystem = GameCore.GetSystem<CreatorSystem>();
        _bullet = GameCore.GetSystem<ResourceSystem>().GetResource(AmmoName);
    }

    private void CreateAmmoAndShoot(Transform target)
    {
        GameObject _newBullet = _creatorSystem.AppendGameObject(_bullet, AmmoName);
        Transform trans = _newBullet.GetComponent<Transform>();
        _newBullet.SetActive(true);
        _newBullet.AddComponent<Bullet>();
        _newBullet.GetComponent<Bullet>().isFromTower = true;
        trans.position = _gameObject.transform.position;
        //trans.rotation = Quaternion.FromToRotation(target.transform.up, _gameObject.transform.up);
        //trans.LookAt(target);
        Vector3 targetDir = target.position - _gameObject.transform.position;
        Vector3 newDir = Vector3.RotateTowards(_gameObject.transform.forward, targetDir,100,0);
        //trans.Rotate(newDir);
        _newBullet.GetComponent<Rigidbody2D>().AddForce(newDir * 0.1f);
        AutoRemove();
    }

    public void AutoRemove()
    {
        List<GameObject> _list = _creatorSystem.GetTypeList(AmmoName);
        if (_list.Count > 30)
        {
            Destroy(_list[0]);
            _list.RemoveAt(0);
        }
    }

    public void Shotting(GameObject tower)
    {
        int i = 0;
        bool attacked = false;
        Collider2D[] hitColliders = { };
        _gameObject = tower;
        hitColliders = Physics2D.OverlapCircleAll(_gameObject.transform.position, 10);

        while (i < hitColliders.Length && !attacked)
        {
            //hitColliders[i].SendMessage("AddDamage");
            if (hitColliders[i].tag == "Monster")
            {
                CreateAmmoAndShoot(hitColliders[i].transform);
                attacked = true;
            }
            i++;
        }   
    }
}

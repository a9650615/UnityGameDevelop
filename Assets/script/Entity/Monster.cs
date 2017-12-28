using UnityEngine;
using System.Collections;

public class Monster : CanBeAttack
{
    public float speed = 3.0f;
    public float viewRange = 10f;
	public float updateTargetTime = 4f;
    public float attackTime = 1f;
    public float attackRange = 0.5f;
    public int attack = 10;

    private Vector2 oldPosition;
    private float nowTargetTime = 0;

    public override string GetName()
    {
        oldPosition = transform.position;
        return "Monster";
    }

    public override Vector2 GetOffset()
    {
        return new Vector2(12, 30);
    }

    public override int BeAttack(int attack)
    {
        return hp = hp - attack;
    }

    public override void Start()
    {
        gameObject.tag = "Monster";
    }


	// Update is called once per frame
	void Update()
	{
        bool stopMove = false;
        bool isAttack = false;
        nowTargetTime += Time.deltaTime;
		int i = 0;
        Collider2D[] hitColliders = {};
        hitColliders = Physics2D.OverlapCircleAll(transform.position, viewRange);
        oldPosition = transform.position;

        if (nowTargetTime > attackTime)
        {
            isAttack = true;
            nowTargetTime = 0;
        }

        while (i < hitColliders.Length && !stopMove)
        {
            //hitColliders[i].SendMessage("AddDamage");
            if (hitColliders[i].tag != "Monster" && hitColliders[i].tag != "MapBlock")
            {
                //Debug.Log(hitColliders[i].tag);
                if (hitColliders[i].tag == "CanCrack" || hitColliders[i].tag == "Player")
                {
                    if (isAttack&&hitColliders[i].tag == "CanCrack" && Vector3.Distance(gameObject.transform.position, hitColliders[i].transform.position) < attackRange)
                    {
                        hitColliders[i].GetComponent<CanBeAttack>().BeAttack(attack);
					}
                    float step = speed * Time.deltaTime;
                    gameObject.transform.position = Vector2.MoveTowards(oldPosition, hitColliders[i].transform.position, step);
				}
            }
            i++;
        }
	}
}

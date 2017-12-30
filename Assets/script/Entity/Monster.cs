using UnityEngine;
using System.Collections;

public class Monster : CanBeAttack
{
    public float speed = 3.0f;
    public float viewRange = 10f;
	public float updateTargetTime = 4f;
    public float attackTime = 1f;
    public float searchTargetTime = 2f;
    private float searchTime = 1f;
    public float attackRange = 0.5f;
    public int attack = 10;

    private Vector2 oldPosition;
    private float nowTargetTime = 0;
    private GameObject targetObj;
    private Vector3 target;
    private Vector3 randTarget;
    private bool isSearch = false;
    private bool isFinded = false;

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
        randTarget = gameObject.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
    }


	// Update is called once per frame
	void Update()
	{
        bool stopMove = false;
        bool isAttack = false;
        nowTargetTime += Time.deltaTime;
        searchTime += Time.deltaTime;
		int i = 0;
        Collider2D[] hitColliders = {};
        hitColliders = Physics2D.OverlapCircleAll(transform.position, viewRange);
        oldPosition = transform.position;
        isSearch = false;
        if (nowTargetTime > attackTime)
        {
            isAttack = true;
            nowTargetTime = 0;
        }

        if (searchTime > searchTargetTime)
        {
            isSearch = true;
            searchTime = 0;
            targetObj = null;
            randTarget = gameObject.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
            //Debug.Log("research");
        }

        if (targetObj == null)
        {
            //Debug.Log(gameObject.transform.position);
            target = randTarget;
        }
        else
        {
            target = targetObj.transform.position;
        }

        while (i < hitColliders.Length && !stopMove)
        {
            //hitColliders[i].SendMessage("AddDamage");
            if (hitColliders[i].tag != "Monster" && hitColliders[i].tag != "MapBlock")
            {
                //Debug.Log(hitColliders[i].tag);
                if (hitColliders[i].tag == "CanCrack" || hitColliders[i].tag == "Player")
                {
                    if (isAttack && Vector3.Distance(gameObject.transform.position, hitColliders[i].transform.position) < attackRange)
                    {
                        //Debug.Log();
                        hitColliders[i].GetComponent<CanBeAttack>().BeAttack(attack);
					}
                    if (isSearch || targetObj == null)
                    {
                        targetObj = hitColliders[i].gameObject;
                        target = hitColliders[i].gameObject.transform.position;
						stopMove = true;
                    }
                }
            }
            i++;
        }
		float step = speed * Time.deltaTime;
        if (!isSearch)
        gameObject.transform.position = Vector2.MoveTowards(oldPosition, target, step);
	}
}

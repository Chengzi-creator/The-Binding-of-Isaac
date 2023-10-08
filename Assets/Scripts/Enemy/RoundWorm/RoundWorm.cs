using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundWorm : LivingEntity
{
    [Header("战斗")]
    public Transform Reyes; //这是RoundWorm的攻击点
    public Transform target;

    public float damage = 1f;
 	public float spawnRadius = 5.0f; // 随机生成位置的半径
	private float emergenceInterval = 2f; // 钻进到钻出地面的间隔
	private float emergeTimer = 0f; // 用于计时出现间隔
	private int time = 0;

    public GameObject player; // 玩家角色
    public GameObject bulletPrefab; // 子弹预制体
    public GameObject roundPrefab; //敌人的预制体
    
    public bool isEmerging = false; // 是否正在从地下出现
	public bool shoot = false; 
    
	private CapsuleCollider2D capsuleCollider; // 胶囊碰撞体组件
	protected override void Start()
    {   
        base.Start();
		Reyes = transform.Find("REyes");
    }
	
	public void Initialize()
	{
   		enabled = true;
		// 启用胶囊碰撞体组件（这里启用似乎不太行
        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = true;
        }
	}


	void Update()
    {	
       Move();
    }
	
	void Move()
	{	
		// 计时射击间隔，同时执行动画
        emergeTimer += Time.deltaTime;
        if (!isEmerging && emergeTimer >= emergenceInterval)
        {	
			isEmerging = true; 
		}
		if (isEmerging && emergeTimer >= emergenceInterval + 1.0f)
		{	
			if(time == 0)
			{
				shoot = true;
				Shoot();
				shoot = false;
				time++;
			}
			isEmerging = false; // 设置为不在出现状态.执行退场动画
		}
		if (!isEmerging && emergeTimer >= emergenceInterval + 2.0f)
		{	
			emergeTimer = 0f;
			float randomAngle = Random.Range(0f, 360f);
			Vector3 spawnPosition = player.transform.position + Quaternion.Euler(0, 0, randomAngle) * Vector3.right * spawnRadius;
			MoveToPosition(spawnPosition);
		}
	}

    void MoveToPosition(Vector3 targetPosition)
    {
        Destroy(gameObject);//销毁当前敌人
        //在目标位置生成新的敌人
        GameObject newEnemy = Instantiate(roundPrefab, targetPosition, Quaternion.identity);
        RoundWorm roundWorm = newEnemy.GetComponent<RoundWorm>();
        if (roundWorm == null)
        {
            roundWorm = newEnemy.AddComponent<RoundWorm>();
        }
		// 添加胶囊碰撞体组件
    	capsuleCollider = newEnemy.AddComponent<CapsuleCollider2D>();
		roundWorm.Initialize(); 
		// 获取新生成的敌人的子对象
        Transform child1 = newEnemy.transform.Find("head"); 
		Transform child2 = newEnemy.transform.Find("hole"); 
        // 启用子物体上的Animator组件和脚本
        if (child1 != null)
        {
            Animator childAnimator1 = child1.GetComponent<Animator>();
            if (childAnimator1 != null)
            {
                childAnimator1.enabled = true;
            }

            RoundWormUpper childScript1 = child1.GetComponent<RoundWormUpper>();
            if (childScript1 != null)
            {
                childScript1.enabled = true;
            }
		}
		if (child2 != null)
        {
            Animator childAnimator2 = child2.GetComponent<Animator>();
            if (childAnimator2 != null)
            {
                childAnimator2.enabled = true;
            }

            RoundWormLower childScript2 = child2.GetComponent<RoundWormLower>();
            if (childScript2 != null)
            {
                childScript2.enabled = true;
            }
		}
    }

    void Shoot()
    {
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = Reyes.position; //射击点
        Vector3 playerPosition = target.position; //角色
        Vector3 shootDirection = (playerPosition - transform.position).normalized; //设计方向
        bullet.GetComponent<Bullet>().SetSpeed(shootDirection);
    }
}

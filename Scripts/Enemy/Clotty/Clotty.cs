using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Clotty : LivingEntity
{
    [Header("AI")]
    public Transform target;
    public AIPath aiPath;
    [Header("战斗")]
    public float damage = 1f;
    public float hitRate = 2.5f;//攻击间隔
    private float _lastHit;
    public GameObject bulletPrefab; //子弹（眼泪
    private Transform ShootPoint; 
    private Animator _animator;
    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
        ShootPoint = transform.Find("ShootPoint");
    }


    void Update()
    {
        if (target == null)
        {
            return;
        }

        aiPath.destination = target.position;
        if (aiPath.reachedDestination)
        {
            //撞到
            _animator.SetBool("isMoving", false);
            if (Time.time > _lastHit + 1/hitRate)
            {
                Shoot();
                _lastHit = Time.time;
                
            }
        }
        else
        {
            _animator.SetBool("isMoving", true);
        }
    }
    
    void Shoot()
    {
        // 创建四个子弹，分别朝上、下、左、右四个方向
        for (int i = 0; i < 4; i++)
        {
            // 创建子弹并设置位置为ShootPoint的位置
            GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
            bullet.transform.position = ShootPoint.position;

            // 计算子弹的速度方向
            Vector2 shootDirection = Vector2.zero;

            // 根据i的值来确定射击方向
            switch (i)
            {
                case 0: // 上
                    shootDirection = Vector2.up;
                    break;
                case 1: // 下
                    shootDirection = Vector2.down;
                    break;
                case 2: // 左
                    shootDirection = Vector2.left;
                    break;
                case 3: // 右
                    shootDirection = Vector2.right;
                    break;
            }

            // 设置子弹速度
            bullet.GetComponent<Bullet>().SetSpeed(shootDirection);
        }
    }

}


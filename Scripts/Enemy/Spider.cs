using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Spider : LivingEntity
{   
    [Header("AI")]
    public Transform target;
    public AIPath aiPath;
    [Header("战斗")]
    public Transform Seyes; //这是Spider的攻击点
    public LayerMask whatToHit;
    public float damage = 0.5f;

    public float hitRate = 1.0f;
    private float _lastHit;
    private Animator _animator;
    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
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
                Hit();
                _lastHit = Time.time;
                
            }
        }
        else
        {
            _animator.SetBool("isMoving", true);
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // 检查碰撞对象是否带有 "Player" 标签
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         // 尝试获取 PlayerController 组件
    //         PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
    //         //if (pc != null)
    //         //{
    //         Debug.Log("okk");
    //         if (pc.MyCurrentHealth >= 0f)
    //         {   
    //             pc.ChangeHealth(-0.5f);
    //             //Destroy(this.gameObject);
    //         }
    //         // }
    //     }
    // }
    // 没有实践成功的攻击方方式============================

    private void Hit()
    {
        // Vector3 selfPosition = transform.position;
        // //面向对象！发射射线（攻击准度好像不高）
        // Vector3 targetDiection = (target.position - selfPosition).normalized; //加的是偏移值offset，可以后续自己调
        // RaycastHit2D hit2D = Physics2D.Raycast(selfPosition, targetDiection, aiPath.endReachedDistance + 2.0f, whatToHit);
        // 获取Spider的攻击点位置
        Vector3 eyesPosition = Seyes.position;
        // 计算射线方向，从Spider的眼睛指向目标
        Vector3 targetDirection = (target.position - eyesPosition).normalized;
        // 发射射线，确保射线长度足够长，以涵盖攻击范围
        RaycastHit2D hit2D = Physics2D.Raycast(eyesPosition, targetDirection, aiPath.endReachedDistance + 5.0f, whatToHit);
        if (hit2D.collider != null)
        {
            Debug.Log("okk");
            IDamageable damageable = hit2D.transform.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
        }
        
    }
}

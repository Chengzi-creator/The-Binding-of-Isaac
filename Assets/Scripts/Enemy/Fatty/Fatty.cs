using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Fatty : LivingEntity
{
    [Header("AI")]
    public Transform target;
    public AIPath aiPath;
    [Header("战斗")]
    public Transform Fattybody; //这是Fatty的攻击点
    public LayerMask whatToHit;
    public float damage = 1.5f;

    public float hitRate = 1.0f;
    private float _lastHit;
    //private Animator _animator;

    protected override void Start()
    {
        base.Start();
        //_animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
    }
    
    void Update()
    {
        if (target == null )
        {
            return;
        }

        aiPath.destination = target.position;
        if (aiPath.reachedDestination)
        {
            //撞到
            //_animator.SetBool("isMoving", false);
            if (Time.time > _lastHit + 1/hitRate)
            {
                Hit();
                _lastHit = Time.time;
                
            }
        }
        else
        {
            //_animator.SetBool("isMoving", true);
        }
    }
    
    private void Hit()
    {
       
        // 获取Fatty的攻击点位置
        Vector3 peePosition = Fattybody.position;
        // 计算射线方向，从Spider的眼睛指向目标
        Vector3 targetDirection = (target.position - peePosition).normalized;
        // 发射射线，确保射线长度足够长，以涵盖攻击范围
        RaycastHit2D hit2D = Physics2D.Raycast(peePosition, targetDirection, aiPath.endReachedDistance + 5.0f, whatToHit);
        if (hit2D.collider != null)
        {
            Debug.Log("okk");
            IDamageable damageable = hit2D.transform.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
        }
    }
}

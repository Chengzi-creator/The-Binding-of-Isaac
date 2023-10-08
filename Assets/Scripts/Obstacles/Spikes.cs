using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : LivingEntity 
{ 
    public float damage = 0.5f;
    public float hitRate = 1.0f;
    private float _lastHit;
    public Transform target;
    public LayerMask whatToHit;
    protected override void Start()
    {
        base.Start();
    }


    void Update()
    {
        if (Time.time > _lastHit + 1/hitRate)
        {   
            //Debug.Log("okk!");
            
            if (target == null)
            {
                return;
            }
            
            Hit();
            _lastHit = Time.time;
                
        }
    }
    

    private void Hit()
    {
        Vector3 sPosition = transform.position;
        // 计算射线方向，从Spider的眼睛指向目标
        Vector3 targetDirection = (target.position - sPosition).normalized;
        // 发射射线，确保射线长度足够长，以涵盖攻击范围
        RaycastHit2D hit2D = Physics2D.Raycast(sPosition, targetDirection, 1.0f, whatToHit);
        if (hit2D.collider != null)
        {
            Debug.Log("okk");
            IDamageable damageable = hit2D.transform.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
        }
        
    }
}

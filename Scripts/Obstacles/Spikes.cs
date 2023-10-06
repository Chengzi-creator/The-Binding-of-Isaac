using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : LivingEntity 
{ 
    public float damage = 0.5f;
    public float hitRate = 1.0f;
    private float _lastHit;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)//MonoBehavior专属
    {   
        Debug.Log("okk");
        Transform spikesTransform = transform;
        if (Time.time > _lastHit + 1 / hitRate)
        {   
            _lastHit = Time.time;
            // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f); // 向上发射射线
            if (other.CompareTag("Player")) // 如果射线碰到了"Player"标签的物体
            {
                Debug.Log("okk");
                IDamageable damageable = spikesTransform.GetComponent<IDamageable>();
                damageable?.TakeDamage(damage);
            }
        }
    }
}

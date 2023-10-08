using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHit : MonoBehaviour
{   
    public float bombTime = 2.0f; // 延迟爆炸时间
    public float damageAmount; // 爆炸伤害值
    public Transform body;
    public GameObject bombPrefab;
    private bool hasExploded = false; // 用于标记是否已经执行过爆炸逻辑
    
    private void Start()
    {   
        //Debug.Log("okk");
        // 启动协程，延迟2秒后执行爆炸逻辑
        //StartCoroutine(ExplodeAfterDelay(2.0f));
    }

    private void Update()
    {   
        Debug.Log("okk");
        StartCoroutine(ExplodeAfterDelay(2.0f));
    }

    private IEnumerator ExplodeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!hasExploded)
        {
            // 处理伤害逻辑
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 3.0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // 如果是玩家，跳过伤害
                    continue;
                }

                IDamageable damageable = collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damageAmount);
                }
            }
            // 销毁炸弹
            ObjectPool.Instance.PushObject(gameObject);
        }
    }
}

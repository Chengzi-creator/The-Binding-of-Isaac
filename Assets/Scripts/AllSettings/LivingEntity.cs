using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour,IDamageable
{
    public float startHealth;

    public float Health;
    // {
    //     get;
    //     private set;
    // }

    public bool IsDead;
    public event Action OnDeath;//死亡触发的事件，到后面怪物死亡掉落东西，或者摧毁可破坏物品

    protected virtual void Start()
    {
        Health = startHealth;
    }
    public virtual void TakeDamage(float damage)
    {   
        Health -= damage;

        if (Health > 0 || IsDead)
        {
            return;
        }
        IsDead = true;
        OnDeath?.Invoke();//判断是否为空
        // 在协程中等待0.5秒后销毁游戏对象
        StartCoroutine(DestroyAfterDelay(0.1f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 在0.5秒后销毁游戏对象
        Destroy(gameObject);
    }
}
     
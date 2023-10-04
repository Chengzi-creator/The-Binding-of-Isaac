using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour,IDamageable
{
    public float startHealth;

    protected float Health
    {
        get;
        private set;
    }

    protected bool IsDead;
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
        Destroy(gameObject);
    }
}

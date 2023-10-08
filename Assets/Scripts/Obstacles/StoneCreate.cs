using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoneCreate :LivingEntity
{
    public override void TakeDamage(float damage)//重写
    {
        if (damage >= Health && !IsDead)
        {
            OnDeath += () => { Debug.Log("DIE"); };
        }
        //可以做很多？关于死亡的
        //死亡特效，音效
        base.TakeDamage(damage);
    }
}
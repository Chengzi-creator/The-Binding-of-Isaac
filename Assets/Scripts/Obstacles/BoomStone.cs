using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomStone : LivingEntity
{
    public GameObject bombPrefab; // 炸弹预制体
    public override void TakeDamage(float damage)
    {
        if (damage >= Health && !IsDead)
        {
            OnDeath += () => { GenerateBomb(); }; // 在死亡时生成炸弹
        }

        // 其他死亡逻辑
        base.TakeDamage(damage);
    }

    private void GenerateBomb()
    {
        // 在物体位置生成炸弹
        Vector3 bombPosition = transform.position;
        // 如果需要调整炸弹位置，可以在这里修改 bombPosition

        GameObject bombObject = Instantiate(bombPrefab, bombPosition, Quaternion.identity);
        bombObject.SetActive(true);
    }
}


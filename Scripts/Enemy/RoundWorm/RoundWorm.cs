using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundWorm : LivingEntity //协程？
{
    [Header("战斗")] 
    public Transform Reyes; //这是RoundWorm的攻击点
    public Transform target;
    public float damage = 1f;
    public GameObject player; // 玩家角色
    public float spawnRadius = 10.0f; // 随机生成位置的半径
    public GameObject bulletPrefab; // 子弹预制体
    public GameObject roundPrefab; //敌人的预制体
    public float emergenceInterval = 2f; // 钻进到钻出地面的间隔
    private bool isEmerging = false; // 是否正在从地下出现

    protected override void Start()
    {   
        base.Start();
        StartCoroutine(EmergeRoutine());
        Reyes = transform.Find("REyes");
    }

    IEnumerator EmergeRoutine()
    {
        while (true)
        {
            if (!isEmerging)
            {
                // 随机选择一个角度
                float randomAngle = Random.Range(0f, 360f);
                // 计算生成位置
                Vector3 spawnPosition = player.transform.position +
                                        Quaternion.Euler(0, 0, randomAngle) * Vector3.right * spawnRadius;
                // 移动到生成位置
                MoveToPosition(spawnPosition);
                yield return new WaitForSeconds(1.0f); // 等待一段时间以完成出现动画
                // 发射子弹
                Shoot();
                isEmerging = true; // 设置为正在出现状态
            }
            else
            {
                yield return new WaitForSeconds(1.0f); // 等待1秒
                // 钻入地面
                RetreatToGround();
                isEmerging = false; // 设置为不在出现状态
            }

            yield return new WaitForSeconds(emergenceInterval); // 控制出现和发射的时间间隔
        }
    }

    void RetreatToGround()
    {
        //在这里播放钻入地面的动画
    }

    void MoveToPosition(Vector3 targetPosition)
    {
       //试图直接生成一个新的预制体，删除这个，血量回满？继承血量想不出来（
       // 销毁当前敌人
       Destroy(gameObject);
    
       // 在目标位置生成新的敌人，可以使用Instantiate方法
       Instantiate(roundPrefab, targetPosition, Quaternion.identity);
    }

    void Shoot()
    {
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = Reyes.position; //射击点
        Vector3 playerPosition = target.position; //角色
        Vector3 shootDirection = (playerPosition - transform.position).normalized;//设计方向
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(0f, Vector3.forward) * shootDirection);
    }
}
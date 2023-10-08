using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;


public class EnemySpawner : MonoBehaviour
{   
    //创建一个嵌套的类，用于存储一波敌人的所有必要数据
    [System.Serializable]
    public class Wave
    {
        public string waveName; //用于定义wave的名称
        public List<EnemyGroup> enemyGroups;
        public int waveQuota; //用于定义在波次中生成的敌人总数
        public float spawnInterval;//用于定义间隔来产生敌人
        public int spawnCount; //生成计数用于定义此波中已经生成的敌人数量
        
    }
    
    [System.Serializable]
    public class EnemyGroup //控制敌人的类型
    {
        public string enemyName;//名字
        public int enemyCount;//敌人数量
        public int spawnCount; //生成计数用于定义此波中已经生成的敌人数量
        public GameObject enemyPrefab;
    }
    
    public List<Wave> waves;//记录所有波数
    public int currentWaveCount;//波次中敌人的数量
    private Transform player;
    
    void Start()
    {
        //player = FindObjectOfType<Player>().transform;
        CalculateWaveQuota();
        SpawnEnemies();
    }
    
    void Update()
    {
        
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;//初始化
        //每次循环遍历所有敌人，waves数组
        foreach (var enemyGroup in waves[currentWaveQuota].enemyGroups)
        {
            //之后的每次迭代会将当前敌人组的敌人数量添加到当前的waveQuota中
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {   //在敌人内部生成敌人，通过比较波数
        //检查当前wave中是否生成了最小数量的敌人
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota)
        {
            //如果敌人生成最少，则当前波尚未生成，该函数继续执行
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {   //这个循环中只检查这种类型的敌人的最小数量
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {   
                    // 定义房间边界
                    TilemapCollider2D roomBounds = GetComponent<TilemapCollider2D>();
                    float minX = roomBounds.bounds.min.x;
                    float maxX = roomBounds.bounds.max.x;
                    float minY = roomBounds.bounds.min.y;
                    float maxY = roomBounds.bounds.max.y;
                    //
                    // 创建随机位置，确保在房间边界内
                    float randomX = Random.Range(minX, maxX);
                    float randomY = Random.Range(minY, maxY);
                    Vector2 spawnPosition = new Vector2(randomX, randomY);
                    //创建随机位置,基于玩家
                    //Vector2 spawnPosition = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));
                    Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);
                    //记录数量
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;

                }
            }
           
        }
    }
}

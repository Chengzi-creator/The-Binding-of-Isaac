using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager1 : MonoBehaviour
{
   [SerializeField] private Transform[] spawnPoints;//表示怪物出生点
   [SerializeField] private MonoBehaviour playerEntity;
   public Wave1[] waves1;//波数信息
   private Wave1 _currentWave1;//当前波
   private int _currentWaveIndex1;
   public int _enemyRemaingaAliveCount1;
   
   private void Start()
   {
      if (spawnPoints.Length == 0)
      {
         Debug.LogError("Can not find point");
         return;
      }

      StartCoroutine(NextWaveCoroutine());
   }
   
   //协程方法
   private IEnumerator NextWaveCoroutine()
   {
      _currentWaveIndex1++;
      if (_currentWaveIndex1 - 1 < waves1.Length) //波数正确才执行
      {
         _currentWave1 = waves1[_currentWaveIndex1 - 1];
         _enemyRemaingaAliveCount1 = _currentWave1.count;
            
         //for循环遍历敌人数量
         for (int i = 0; i < _currentWave1.count; i++)
         {
            int spawnIndex = Random.Range(0, spawnPoints.Length);//最小值为0，最大值为长度
            //几个出生点中随机选一个地方出现
            Spider spider = Instantiate(_currentWave1.spider,spawnPoints[spawnIndex].position,Quaternion.identity);
            spider.target = playerEntity.transform;
            spider.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            yield return new WaitForSeconds(_currentWave1.timeBetweenSpawn);
         }
      }
   }

   private void OnEnemyDeath()
   {
      //当当前波敌人数为0，则下一波
      _enemyRemaingaAliveCount1--;
      if (_enemyRemaingaAliveCount1 == 0)
      {
         StartCoroutine(NextWaveCoroutine());
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager3 : MonoBehaviour
{
   [SerializeField] private Transform[] spawnPoints;//表示怪物出生点
   [SerializeField] private MonoBehaviour playerEntity;
   public Wave3[] waves3;//波数信息
   private Wave3 _currentWave3;//当前波
   private int _currentWaveIndex3;
   public int _enemyRemaingaAliveCount3;
   
   public void Start()
   {
      if (spawnPoints.Length == 0)
      {
         Debug.LogError("Can not find point");
         return;
      }

      StartCoroutine(NextWaveCoroutine());
   }
   
   //协程方法
   public IEnumerator NextWaveCoroutine()
   {
      _currentWaveIndex3++;
      if (_currentWaveIndex3 - 1 < waves3.Length) //波数正确才执行
      {
         _currentWave3 = waves3[_currentWaveIndex3 - 1];
         _enemyRemaingaAliveCount3 = _currentWave3.count;
            
         //for循环遍历敌人数量
         for (int i = 0; i < _currentWave3.count; i++)
         {
            int spawnIndex = Random.Range(0, spawnPoints.Length);//最小值为0，最大值为长度
            //几个出生点中随机选一个地方出现
            Spider spider = Instantiate(_currentWave3.spider,spawnPoints[spawnIndex].position,Quaternion.identity);
            spider.target = playerEntity.transform;
            spider.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            Clotty clotty = Instantiate(_currentWave3.clotty,spawnPoints[spawnIndex].position,Quaternion.identity);
            clotty.target = playerEntity.transform;
            clotty.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            yield return new WaitForSeconds(_currentWave3.timeBetweenSpawn);
         }
      }
   }

   public void OnEnemyDeath()
   {
      //当当前波敌人数为0，则下一波
      _enemyRemaingaAliveCount3--;
      // if (_enemyRemaingaAliveCount3 == 0)
      // {
      //    StartCoroutine(NextWaveCoroutine());
      // }
   }
}

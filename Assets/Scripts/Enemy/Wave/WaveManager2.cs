using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager2 : MonoBehaviour
{
   [SerializeField] private Transform[] spawnPoints;//表示怪物出生点
   [SerializeField] private MonoBehaviour playerEntity;
   public Wave2[] waves2;//波数信息
   private Wave2 _currentWave2;//当前波
   private int _currentWaveIndex2;
   public int _enemyRemaingaAliveCount2;
   
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
      _currentWaveIndex2++;
      if (_currentWaveIndex2 - 1 < waves2.Length) //波数正确才执行
      {
         _currentWave2 = waves2[_currentWaveIndex2 - 1];
         _enemyRemaingaAliveCount2 = _currentWave2.count;
            
         //for循环遍历敌人数量
         for (int i = 0; i < _currentWave2.count; i++)
         {
            int spawnIndex = Random.Range(0, spawnPoints.Length);//最小值为0，最大值为长度
            //几个出生点中随机选一个地方出现
            Fatty fatty= Instantiate(_currentWave2.fatty,spawnPoints[spawnIndex].position,Quaternion.identity);
            fatty.target = playerEntity.transform;
            fatty.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            yield return new WaitForSeconds(_currentWave2.timeBetweenSpawn);
         }
      }
   }

   private void OnEnemyDeath()
   {
      //当当前波敌人数为0，则下一波
      _enemyRemaingaAliveCount2--;
      if (_enemyRemaingaAliveCount2 == 0)
      {
         StartCoroutine(NextWaveCoroutine());
      }
   }
}

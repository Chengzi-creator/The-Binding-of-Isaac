using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager5 : MonoBehaviour
{
   [SerializeField] private Transform[] spawnPoints;//表示怪物出生点
   [SerializeField] private MonoBehaviour playerEntity;
   public Wave5[] waves5;//波数信息
   private Wave5 _currentWave5;//当前波
   private int _currentWaveIndex5;
   public int _enemyRemaingaAliveCount5;
   
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
      _currentWaveIndex5++;
      if (_currentWaveIndex5 - 1 < waves5.Length) //波数正确才执行
      {
         _currentWave5 = waves5[_currentWaveIndex5 - 1];
         _enemyRemaingaAliveCount5 = _currentWave5.count;
            
         //for循环遍历敌人数量
         for (int i = 0; i < _currentWave5.count; i++)
         {
            int spawnIndex = Random.Range(0, spawnPoints.Length);//最小值为0，最大值为长度
            //几个出生点中随机选一个地方出现
            Spider spider = Instantiate(_currentWave5.spider,spawnPoints[spawnIndex].position,Quaternion.identity);
            spider.target = playerEntity.transform;
            spider.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            Clotty clotty = Instantiate(_currentWave5.clotty,spawnPoints[spawnIndex].position,Quaternion.identity);
            clotty.target = playerEntity.transform;
            clotty.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            Fatty fatty= Instantiate(_currentWave5.fatty,spawnPoints[spawnIndex].position,Quaternion.identity);
            fatty.target = playerEntity.transform;
            fatty.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            RoundWorm roundworm = Instantiate(_currentWave5.roundworm,spawnPoints[spawnIndex].position,Quaternion.identity);
            roundworm.target = playerEntity.transform;
            roundworm.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            yield return new WaitForSeconds(_currentWave5.timeBetweenSpawn);
         }
      }
   }

   private void OnEnemyDeath()
   {
      //当当前波敌人数为0，则下一波
      _enemyRemaingaAliveCount5--;
      if (_enemyRemaingaAliveCount5 == 0)
      {
         StartCoroutine(NextWaveCoroutine());
      }
   }
}

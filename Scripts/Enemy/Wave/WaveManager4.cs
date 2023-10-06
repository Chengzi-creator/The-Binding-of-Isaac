using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager4 : MonoBehaviour
{
   [SerializeField] private Transform[] spawnPoints;//表示怪物出生点
   [SerializeField] private MonoBehaviour playerEntity;
   public Wave4[] waves4;//波数信息
   private Wave4 _currentWave4;//当前波
   private int _currentWaveIndex4;
   public int _enemyRemaingaAliveCount4;
   
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
      _currentWaveIndex4++;
      if (_currentWaveIndex4 - 1 < waves4.Length) //波数正确才执行
      {
         _currentWave4 = waves4[_currentWaveIndex4 - 1];
         _enemyRemaingaAliveCount4 = _currentWave4.count;
            
         //for循环遍历敌人数量
         for (int i = 0; i < _currentWave4.count; i++)
         {
            int spawnIndex = Random.Range(0, spawnPoints.Length);//最小值为0，最大值为长度
            //几个出生点中随机选一个地方出现
            Spider spider = Instantiate(_currentWave4.spider,spawnPoints[spawnIndex].position,Quaternion.identity);
            spider.target = playerEntity.transform;
            spider.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            Clotty clotty = Instantiate(_currentWave4.clotty,spawnPoints[spawnIndex].position,Quaternion.identity);
            clotty.target = playerEntity.transform;
            clotty.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            Fatty fatty= Instantiate(_currentWave4.fatty,spawnPoints[spawnIndex].position,Quaternion.identity);
            fatty.target = playerEntity.transform;
            fatty.OnDeath += OnEnemyDeath;//监听死亡事件，便于进行下一波的敌人生成
            yield return new WaitForSeconds(_currentWave4.timeBetweenSpawn);
         }
      }
   }

   private void OnEnemyDeath()
   {
      //当当前波敌人数为0，则下一波
      _enemyRemaingaAliveCount4--;
      if (_enemyRemaingaAliveCount4 == 0)
      {
         StartCoroutine(NextWaveCoroutine());
      }
   }
}

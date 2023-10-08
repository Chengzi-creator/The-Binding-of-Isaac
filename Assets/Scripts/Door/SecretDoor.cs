using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SecretDoor : MonoBehaviour
{
    public WaveManager2 waveManager; // 引用WaveManager2脚本
    public int enemyRemainingCount;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            waveManager = FindObjectOfType<WaveManager2>();
            enemyRemainingCount = waveManager._enemyRemaingaAliveCount2;
            if (enemyRemainingCount == 0)
            {
                SceneManager.LoadScene("SecondScene");
                //把当前活动场景的属性拿出，+1即到下一个场景
            }
           
            ObjectPool.Instance.Initialize(); // 初始化对象池
        }
    }
}

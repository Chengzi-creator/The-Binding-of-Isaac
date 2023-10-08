using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create4 : MonoBehaviour
{
    public WaveManager2 waveManager; // 引用WaveManager4脚本
    public GameObject[] dropItems; // 存储所有可能的掉落物品

    private bool hasGenerated = false; // 表示是否已生成掉落物品

    public void Update()
    {
        if (!hasGenerated && waveManager != null && waveManager.enabled && waveManager._enemyRemaingaAliveCount2 == 0)
        {
            // 生成随机数，确定掉落物品
            int randomNumber = UnityEngine.Random.Range(0, dropItems.Length);
            // 选择掉落物品并生成在当前位置
            GameObject selectedDropItem = dropItems[randomNumber];
            Instantiate(selectedDropItem, transform.position, Quaternion.identity);
            
            hasGenerated = true; // 将标志位设置为已生成
        }
    }
}

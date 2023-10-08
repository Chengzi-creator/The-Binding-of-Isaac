using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create5 : MonoBehaviour
{
    public WaveManager5 waveManager; // 引用WaveManager1脚本
    public GameObject[] dropItems; // 存储所有可能的掉落物品
    public GameObject wavamanager5;
    private bool hasGenerated = false; // 表示是否已生成掉落物品

    public void Update()
    {
        if (!hasGenerated && waveManager != null)
        {   
            Debug.Log("一");
            // 检查 WaveManager3 是否启用，并且 _enemyRemaingaAliveCount3 为 0
            if (waveManager != null && wavamanager5.activeSelf && waveManager._enemyRemaingaAliveCount5 == -9)
            {   
                Debug.Log("二");
                // 生成随机数，确定掉落物品
                int randomNumber = UnityEngine.Random.Range(0, dropItems.Length);
                // 选择掉落物品并生成在当前位置
                GameObject selectedDropItem = dropItems[randomNumber];
                Instantiate(selectedDropItem, transform.position, Quaternion.identity);

                hasGenerated = true; // 将标志位设置为已生成
            }
        }
    }
}

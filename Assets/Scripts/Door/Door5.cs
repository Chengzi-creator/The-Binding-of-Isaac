using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door5 : MonoBehaviour
{
    public GameObject targetRoom; // 目标房间
    public GameObject targetDoor; // 引用目标门
    public GameObject wavamanager5;//引用未启用的物体
    public WaveManager5 waveManager; // 引用WaveManager4脚本
    
    public bool canSwitchRooms = false;
    public int enemyRemainingCount;
    
    private void Start()
    {
        
    }

    private void Update()
    {   
        // if (waveManager != null)
        // {
        //     enemyRemainingCount = waveManager._enemyRemaingaAliveCount3;
        //     // 在这里使用 enemyRemainingCount
        // }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {    
            wavamanager5.SetActive(true);
            waveManager = FindObjectOfType<WaveManager5>();
            enemyRemainingCount = waveManager._enemyRemaingaAliveCount5;
            Debug.Log("enemyRemainingCount" + enemyRemainingCount);
            
            canSwitchRooms = false; // 禁用切换房间直到怪物全部清理完毕
            Debug.Log("启用");
            
            if (enemyRemainingCount == -10)
            {   
                Debug.Log("启动");
                canSwitchRooms = true; // 允许切换房间
            }
            if (canSwitchRooms) 
            {
                SwitchRooms();
            }
        }
    }

    private void SwitchRooms()
    {   
        // 获取角色
        GameObject player = GameObject.Find("Body");
       
        if (player != null && targetDoor != null)
        {
            // 将玩家传送到目标门的位置
            Debug.Log("teleport");
            player.transform.position = targetDoor.transform.position;
        }
    }
}

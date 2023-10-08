using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject targetRoom; // 目标房间
    public GameObject targetDoor; // 引用目标门
    public WaveManager1 waveManager; // 引用WaveManager1脚本
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f); // 向上发射射线

        if (other.CompareTag("Player")) // 如果射线碰到了"Player"标签的物体
        {
            if (waveManager != null && waveManager._enemyRemaingaAliveCount1 == 0)
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//掉落物的拾取脚本
public class Hearts : MonoBehaviour
{
    private PlayerHealth playerHealth; // 引用 PlayerController
    void Start()
    {
        // 在 Start 方法中获取 PlayerController 对象的引用
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {   
            Debug.Log("Heart");
            playerHealth.Health += 1;
            Destroy(gameObject);
        }
    }
}


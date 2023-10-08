using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour
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
            playerHealth.startHealth += 1;
            playerHealth.Health += 1;
            Destroy(gameObject);
        }
    }
}

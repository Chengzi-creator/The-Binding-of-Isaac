using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    private PlayerController playerController; // 引用 PlayerController
    
    void Start()
    {
        // 在 Start 方法中获取 PlayerController 对象的引用
        playerController = FindObjectOfType<PlayerController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {   
            Debug.Log("10");
            playerController.bombCount += 10;
            Destroy(gameObject);
        }
    }
}

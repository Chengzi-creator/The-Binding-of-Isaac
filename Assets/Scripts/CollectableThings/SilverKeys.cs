using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverKeys : MonoBehaviour
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
            Debug.Log("SilverKey");
            playerController.silverKey += 1;
            Destroy(gameObject);
        }
    }
}

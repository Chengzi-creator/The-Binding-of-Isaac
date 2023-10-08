using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombTime = 2.0f; // 延迟爆炸时间
    public float damageAmount; // 爆炸伤害值
    
    public Transform body;
    public GameObject bombPrefab;
    private PlayerController playerController; // 引用 PlayerController
    void Start()
    {
        // 在 Start 方法中获取 PlayerController 对象的引用
        playerController = FindObjectOfType<PlayerController>();
    }
    
    void Update()
    {
        Creat();
    }

    public void Creat()
    {
        if (Input.GetKeyDown(KeyCode.C) &&  playerController.bombCount > 0)
        {
            // 在角色脚底生成炸弹
            Vector3 bombPosition = transform.position;
            bombPosition.y -= 1.0f; // 调整炸弹位置，根据角色脚底位置
            
            // 从对象池中获取炸弹
            GameObject bombObject = ObjectPool.Instance.GetObject(bombPrefab);
            bombObject.transform.position = bombPosition;
            bombObject.SetActive(true);
            // 设置炸弹的延迟爆炸时间
            playerController.bombCount--; 
        }
    }
}

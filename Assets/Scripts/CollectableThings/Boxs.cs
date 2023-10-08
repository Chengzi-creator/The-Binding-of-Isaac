using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxs : MonoBehaviour
{
    public class GoldKeys : MonoBehaviour
    {
        private PlayerController playerController; // 引用 PlayerController
        private Shoot shoot;
    
        void Start()
        {
            // 在 Start 方法中获取 PlayerController 对象的引用
            playerController = FindObjectOfType<PlayerController>();
            shoot = FindObjectOfType<Shoot>();
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Player") &&  playerController.silverKey > 0)
            {   
                //箱子好像是掉落其他物品的，但是不如加点属性吧
                playerController.speed++;
                shoot.interval -= (0.5f * shoot.interval);
                Debug.Log("goldKey");
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }
}

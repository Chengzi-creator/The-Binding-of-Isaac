using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//掉落物的拾取脚本
public class CollectableHeart : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    //碰撞检测相关
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            //if (pc.MyCurrentHealth < pc.MyMaxHealth)
            //{
                //pc.ChangeHealth(1);
                Destroy(this.gameObject);
           // }
        }
    }
    //恢复生命，即红心
        
        // if (other.CompareTag("Key"))
        // {
        //     if (pc != null)
        //     {
        //         if (pc.qualify < 5)
        //         {
        //             pc.ChangeHealth(1);
        //             Destroy(this.gameObject);
        //         }
        //     }
        // }//获得前往下一关的资格
    //}
}

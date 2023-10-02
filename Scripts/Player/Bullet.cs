using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;//速度
    public GameObject explosionPrefab;//传入爆炸特效的预制体
    new private Rigidbody2D rigidbody;//刚体
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }//设置子弹速度
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)//在当前眼泪位置生成一个爆炸特效预制体并且销毁子弹
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

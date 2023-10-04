using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;//速度
    public GameObject explosionPrefab;//传入爆炸特效的预制体
    new private Rigidbody2D rigidbody;//刚体
	public float damageAmount; // 子弹伤害值
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }
    //设置子弹速度
    
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D other)//在当前眼泪位置生成一个爆炸特效预制体并且销毁子弹
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!other.CompareTag("Player"))
        // if (collision.gameObject.CompareTag("Player"))
        // {
        //     return; // 如果是玩家物体，不执行后续的代码
        // }

		//======================
        //这里检测触发器无法发射出子弹，所以经过一晚上调整决定检测碰撞，但似乎无法与box与composite碰撞体发生碰撞;
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        //exp.transform.position = transform.position;
        //Destroy(gameObject);
        //ObjectPool.Instance.PushObject(gameObject);
		//======================

        Vector2 startPosition = transform.position; // 子弹的当前位置
        Vector2 direction = rigidbody.velocity.normalized; // 子弹的移动方向
		IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();//使用伤害的接口

        // 发射射线并进行碰撞检测
        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, speed * Time.deltaTime);
		
		// 如果成功获取到接口，调用 TakeDamage 方法传递伤害值
        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);
        }
        // 判断是否有碰撞
        if (hit.collider != null)
        {
            // 碰撞发生，在这里进行碰撞的逻辑
            // hit.collider 可以访问到碰撞到的碰撞体
            // hit.point 可以访问到碰撞点的位置
        
            // 在碰撞点生成爆炸特效
            GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
            exp.transform.position = hit.point;
            // 销毁子弹
            ObjectPool.Instance.PushObject(gameObject);
        }
    }
}

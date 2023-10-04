using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public float interval; //发射间隔
    public GameObject bulletPrefab; //子弹（眼泪
    private Transform Eyes; //发射位置muzzlePos,原本想分左右眼，但有些难崩
    private Vector2 mousePos; //鼠标位置
    //private Vector2 direction; //发射方向
	private Vector2 mouseDirection;
    private float timer; //计时器
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        Eyes = transform.Find("Eyes");
        //RightEye = transform.Find("RightEye");//获取发射位置
        //flipY = transform.localScale.y;
    }

    //确定鼠标方向==================================================
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//鼠标位置为世界坐标中的位置
        shoot();
    }

    void shoot() //让角色头部指向鼠标方向并在按住鼠标时每隔一段时间射击一次
    {
        //用当前鼠标位置减去发射位置并进行标准化就获得了头部需要朝向
        //direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        //transform.right = direction;

		// 计算鼠标指向的角度
		mouseDirection = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
   	 	float mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
    	// 计算角色和鼠标之间的角度差
    	float angleDifference = Mathf.DeltaAngle(transform.rotation.eulerAngles.z, mouseAngle);
        if (Mathf.Abs(angleDifference) <= 180f && (Mathf.Abs(angleDifference) >= 0f))
    	{
        // 鼠标位于左侧上下各 45 度之间时，向正左方发射
        	if ((Mathf.Abs(angleDifference) >= 135f) && mouseDirection.x < 0)
        	{
            // 鼠标在左侧，可以发射向左的子弹
            	if (timer != 0)
        		{
            		timer -= Time.deltaTime;
            		if (timer <= 0)
                		timer = 0;
        		}

        		if (Input.GetButtonDown("Fire1"))
        		{
            		if (timer == 0)
            		{
                		FireLeft();
                		timer = interval;
            		}
        		}
        	}
        	// 鼠标位于右侧上下各 45 度之间时，向正右方发射
        	else if ((Mathf.Abs(angleDifference) <= 45f)  && mouseDirection.x > 0)
        	{
            	// 鼠标在右侧，可以发射向右的子弹
            	if (timer != 0)
        		{
            		timer -= Time.deltaTime;
            		if (timer <= 0)
                		timer = 0;
        		}

        		if (Input.GetButtonDown("Fire1"))
        		{
            		if (timer == 0)
            		{
                		FireRight();
                		timer = interval;
            		}
        		}
        	}
        	// 鼠标位于上侧上下各 45 度之间时，向正上方发射
        	else if ((Mathf.Abs(angleDifference) >= 45f && Mathf.Abs(angleDifference) <= 135f) && mouseDirection.y > 0)
        	{
            	// 鼠标在上侧，可以发射向上的子弹
            	if (timer != 0)
        		{
            		timer -= Time.deltaTime;
            		if (timer <= 0)
                		timer = 0;
        		}

        		if (Input.GetButtonDown("Fire1"))
        		{
            		if (timer == 0)
            		{
                		FireUp();
                		timer = interval;
           		 	}
        		}
       	 	}
        	// 鼠标位于下侧上下各 45 度之间时，向正下方发射
        	else if ((Mathf.Abs(angleDifference) >= 45f && Mathf.Abs(angleDifference) <= 135f) && mouseDirection.y < 0)
    	   {
        	    // 鼠标在下侧，可以发射向下的子弹
				if (timer != 0)
     	  	 	{
            		timer -= Time.deltaTime;
           	 		if (timer <= 0)
                		timer = 0;
        		}

        		if (Input.GetButtonDown("Fire1"))
        		{
            		if (timer == 0)
            		{
                		FireDown();
                		timer = interval;
            		}
        		}
      	  	}
		}
        /*else
        {
			//发射间隔
        	if (timer != 0)
        	{
            	timer -= Time.deltaTime;
            	if (timer <= 0)
                	timer = 0;
        	}

        	if (Input.GetButtonDown("Fire1"))
        	{
            	if (timer == 0)
            	{
                	Fire();
                	timer = interval;
            	}
        	}
		}*/
    }

    /*void Fire()
    {
        //Debug.Log("生成");
        //GameObject bullet = Instantiate(bulletPrefab, Eyes.position, Quaternion.identity);//生成Bullet
        animator.SetTrigger("Shoot");
        
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = Eyes.position;
        
        float angel = Random.Range(-5f,5f);
		bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel,Vector3.forward) * mouseDirection);
    }*/

	void FireLeft()
	{
    	//animator.SetTrigger("Shoot");
    
    	GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
    	bullet.transform.position = Eyes.position;
    
    	float angle = Random.Range(-5f, 5f);
    	bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.left); // 向左射击
	}
	void FireRight()
	{
    	//animator.SetTrigger("Shoot");
    
    	GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
    	bullet.transform.position = Eyes.position;
    
    	float angle = Random.Range(-5f, 5f);
    	bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.right); // 向右射击
	}
	void FireUp()
	{
    	//animator.SetTrigger("Shoot");
    
    	GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
    	bullet.transform.position = Eyes.position;
    
    	float angle = Random.Range(-5f, 5f);
    	bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.up); // 向上射击
	}
	void FireDown()
	{
    	//animator.SetTrigger("Shoot");
    
    	GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
    	bullet.transform.position = Eyes.position;
    
    	float angle = Random.Range(-5f, 5f);
    	bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.down); // 向下射击
	}
}
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
    private Vector2 direction; //发射方向
    private float timer; //计时器
    //private Animator animator;


    void Start()
    {
        //animator = GetComponent<Aniamtor>();
        Eyes = transform.Find("Eyes");
        //RightEye = transform.Find("RightEye");//获取发射位置
        //flipY = transform.localScale.y;
    }

    //确定鼠标方向==================================================
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shoot();
    }

    void shoot() //让角色头部指向鼠标方向并在按住鼠标时每隔一段时间射击一次
    {
        //用当前鼠标位置减去发射位置并进行标准化就获得了头部需要朝向
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.right = direction;

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
    }

    void Fire()
    {
        Debug.Log("生成");
        GameObject bullet = Instantiate(bulletPrefab, Eyes.position, Quaternion.identity);//生成Bullet
        bullet.GetComponent<Bullet>().SetSpeed(direction);
    }
}
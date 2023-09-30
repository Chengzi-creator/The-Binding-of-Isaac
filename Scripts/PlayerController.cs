using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制角色的移动，属性，动画等
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;//移动速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.right * speed * Time.deltaTime);这一步即是检测是否可以向右移动
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平方向的位移，A为-1,D为1，无为0
        float moveY = Input.GetAxisRaw("Vertical");//控制垂直移动方向

        Vector2 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//控制角色的移动，属性等
public class PlayerController : MonoBehaviour
{	
    public PlayerInputControls inputControl;//调用InputSystem；
    
    public Vector2 inputDirection;//方向
    public Rigidbody2D rb; //刚体组件

    public int coinCount = 0;
    public int bombCount = 3;
    public int silverKey = 0;
    public int goldKey = 1;
    public float distance = 10f;
    public float speed = 5f; //移动速度
    
    
    //public int qualify;//是否能进入下一关
    //public GameObject Hearts;//爱心数量
	//==================================================
    // public float MyMaxHealth
    // {
    //     get
    //     {
    //         return maxHealth;
    //     }
    // }//可以从其他脚本中获取这个属性,如果该变量不是public的话
    // public float MyCurrentHealth
    // {
    //     get
    //     {
    //         return currentHealth;
    //     }
    // }//可以从其他脚本中获取这个属性
	//快进到用一个脚本涵盖所有有生命值的！！！！
    //以上为变量=================================================
    private void Awake()
    {   
        rb = GetComponent<Rigidbody2D>();//初始化rb，获取组件
        inputControl = new PlayerInputControls();//创建InputSystem输入的实例
    }
   
    private void OnEnable()
    {
        inputControl.Enable();//物体存在时启用
    }
    
    private void OnDisable()
    {
         inputControl.Disable();//物体不存在时禁用
    }
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {   
        inputDirection = inputControl.Player.Move.ReadValue<Vector2>();//通过键盘输入移动方向
        Move();//移动的函数
    }
    
    //移动==========================================================
    public void Move()
    {
        Vector2 velocity = inputDirection * speed;
        rb.velocity = velocity;//控制人物的移动

        //确保 faceDirx 和 faceDiry 有初始值
        int faceDirx = 1;
        int faceDiry = 1;
        
        // 如果输入方向大于某个阈值，将 faceDirx 和 faceDiry 设置为 1 或 -1
        if (inputDirection.x > 0.1f)
            faceDirx = 1;
        else if (inputDirection.x < -0.1f)
            faceDirx = -1;
        
        if (inputDirection.y > 0.1f)
            faceDiry = 1;
        else if (inputDirection.y < -0.1f)
            faceDiry = -1;
        // 将本地缩放设置为 faceDirx 和 faceDiry 的值
        transform.localScale = new Vector3(faceDirx, 1, faceDiry);
    }
    
}

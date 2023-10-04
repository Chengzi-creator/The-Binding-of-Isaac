using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//控制角色的移动，属性等
public class PlayerController : MonoBehaviour
{	
    public PlayerInputControls inputControl;//调用InputSystem；
    public float speed = 5f;//移动速度
    public Vector2 inputDirection;//方向
    public Rigidbody2D rb; //刚体组件
    
    // private float maxHealth = 3f;//最大生命值
    // private float currentHealth = 3f;//当前生命值
    //后面统一实现吧
    
    public int qualify;//是否能进入下一关
    public GameObject Hearts;
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
	//快进到用一个脚本涵盖所有有生命值的！！！！==========================
    // private float invincibleTime = 1f;//无敌时间1s
    // private float invincibleTimer;//无敌计时器
    // private bool isInvincible;//是否处于无敌状态
    //以上为变量=================================================
    private void Awake()
    {   
        rb = GetComponent<Rigidbody2D>();//初始化rb，获取组件
        inputControl = new PlayerInputControls();//创建InputSystem输入的实例

        //inputControls.Player.Fire.performed += Fire;//+=代表注册函数
        //started为按下去的那个时间点
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
        //currentHealth = 3;
        //invincibleTimer = 0;
    }

    void Update()
    {
       //invincible();
    }

    void FixedUpdate()
    {   
        inputDirection = inputControl.Player.Move.ReadValue<Vector2>();//通过键盘输入移动方向
        Move();//移动的函数
    }
    
    //移动==========================================================
    public void Move()
    {
        // float moveX = Input.GetAxisRaw("Horizontal"); //控制水平方向的位移，A为-1,D为1，无为0
        // float moveY = Input.GetAxisRaw("Vertical");
        // Vector2 position = transform.position;
        // position.x += moveX * speed * Time.deltaTime;
        // position.y += moveY * speed * Time.deltaTime;
        // transform.position = position;
        //以上都是旧的输入系统的方式了，后来更改为新的inputsystem，这段代码就废了喵
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

    //改变玩家的血量====================================================
    // public void ChangeHealth(float amount)
    // {
    //     //Debug.Log(currentHealth + "/" + maxHealth);
    //     //将玩家的血量约束在0和最大之间
    //     currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    //     //Debug.Log(currentHealth + "/" + maxHealth);
    //     //看看函数是否成功
    //     
    //     //如果玩家受到伤害
    //     if (amount < 0)
    //     {
    //         if (isInvincible == true)
    //         {
    //             return;
    //         }
    //
    //         isInvincible = true;
    //         invincibleTimer = invincibleTime;
    //     }
    // }
    //================================================================
    public void Qualification(int amount)
    {
        //将玩家的血量约束在0和最大之间
        qualify = Mathf.Clamp(qualify + amount, 0, 5);
    }
    //判断玩家是否无敌===================================================
    // public void invincible()
    // {
    //     if (isInvincible)
    //     {
    //         invincibleTimer -= Time.deltaTime;
    //         if (invincibleTimer < 0)
    //             isInvincible = false;//倒计时结束以后，解除无敌状态
    //     }
    // }
	
}

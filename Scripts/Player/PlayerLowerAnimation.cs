using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//实现角色下半身的各种动画，为肥仔的制作做铺垫
public class PlayerLowerAnimation : MonoBehaviour
{      
    //用了bool做条件感觉非常轻松==========================
    //public PlayerInputControls inputControl;
    // private Animator anim; //动画条件 
    //
    // void Start()
    // {
    //     anim = GetComponent<Animator>();
    // }
    //
    // void Update()
    // {
    //     //Move();
    //     SetAnimation();
    // }
    
    // public void SetAnimation() //动画朝向判断
    // {
    //     anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
    //     anim.SetFloat("velocityY", Mathf.Abs(rb.velocity.y));
    // }
    private Animator anim; // 动画控制器
    //private Vector2 inputDirection; // 输入方向

    //[Header("动画参数名称")]
    // public string horizontalSpeedParam = "HorizontalSpeed";
    // public string verticalSpeedParam = "VerticalSpeed";

    private void Start()
    {
        anim = GetComponent<Animator>();
        //inputControl = new PlayerInputControls();
    }

    private void Update()
    {
        // 获取输入方向
        //inputDirection = GetInputDirection();
        
        // 根据输入方向设置动画参数
        SetAnimation();
    }

    // private Vector2 GetInputDirection()
    // {
    //     // 使用新的Input System获取输入方向，好难，后面应该会更换为先前的输入方式
    //     //Vector2 inputVector = inputControl.Player.Move.ReadValue<Vector2>();
    //     //return inputVector.normalized;
    // }

    private void SetAnimation()
    {
        // // 根据输入方向来控制角色朝向
        // if (inputDirection.magnitude > 0.1f)
        // {
        //     float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.Euler(0f, 0f, angle);
        // }
        //
        // // 设置动画参数
        // anim.SetFloat("horizontalSpeedParam", Mathf.Abs(inputDirection.x));
        // anim.SetFloat("verticalSpeedParam", Mathf.Abs(inputDirection.y));
        //用了bool做条件感觉非常轻松==========================
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Up", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Up", false);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("LR", true); 
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("LR", false); 
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Down", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Down", false);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("LR", true); 
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("LR", false); 
        }
    }
}

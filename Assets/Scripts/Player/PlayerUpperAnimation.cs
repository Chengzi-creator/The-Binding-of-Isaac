using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUpperAnimation : MonoBehaviour
{
    public Animator headAnimator; // 头部的Animator组件
    private Vector2 mousePos; //鼠标位置
    private Vector2 mouseDirection;

    void Start()
    {
	    headAnimator = GetComponent<Animator>();
    }
    private void Update()
    {	
	    // // 计算头部应该朝向的方向
	    // Vector3 lookDirection = worldMousePosition - transform.position;
	    // // 计算头部应该朝向的角度
	    // float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
	    // // 创建一个目标旋转，使头部平滑旋转到鼠标方向
	    // Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	    // // 使用 Slerp 进行平滑旋转
	    // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	    
	    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//鼠标位置为世界坐标中的位置
        // 计算鼠标指向的角度
		mouseDirection = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
		
   	 	float mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
    	// 计算角色和鼠标之间的角度差
    	float angleDifference = Mathf.DeltaAngle(transform.rotation.eulerAngles.z, mouseAngle);
	    if (Mathf.Abs(angleDifference) <= 180f && (Mathf.Abs(angleDifference) >= 0f))
	    {
		    
		    if ((Mathf.Abs(angleDifference) >= 135f) && mouseDirection.x < 0)
		    {
			    headAnimator.SetBool("LRight", true);
			    headAnimator.SetBool("Up", false);
			    headAnimator.SetBool("Down", false);
			    transform.localScale = new Vector3(-1, 1, 1);
		    }
		    
		    else if ((Mathf.Abs(angleDifference) <= 45f) && mouseDirection.x > 0)
		    {
			    headAnimator.SetBool("LRight", true);
			    headAnimator.SetBool("Up", false);
			    headAnimator.SetBool("Down", false);
			    transform.localScale = new Vector3(1, 1, 1);
		    }
		   
		    else if ((Mathf.Abs(angleDifference) >= 45f && Mathf.Abs(angleDifference) <= 135f) && mouseDirection.y > 0)
		    {
			    headAnimator.SetBool("LRight", false);
			    headAnimator.SetBool("Up", true);
			    headAnimator.SetBool("Down", false);
		    }
		   
		    else if ((Mathf.Abs(angleDifference) >= 45f && Mathf.Abs(angleDifference) <= 135f) && mouseDirection.y < 0)
		    {
			    headAnimator.SetBool("LRight", false);
			    headAnimator.SetBool("Up", false);
			    headAnimator.SetBool("Down", true);
		    }
	    }

	    
        if (Input.GetButtonDown("Fire1"))
        {
            headAnimator.SetBool("Shoot", true); //射击触发器
        }
        if (Input.GetButtonUp("Fire1"))
        {
	        headAnimator.SetBool("Shoot", false); //射击触发器
        }
    }
}

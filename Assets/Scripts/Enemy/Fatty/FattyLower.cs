using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FattyLower : MonoBehaviour
{   
    public Transform target; 
    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        SetAnimation();
    }

    void SetAnimation()
    {
        int faceDirx = 3;
        Vector2 moveDirection = CalculateMoveDirection(); // 根据追踪逻辑计算移动方向
        // 如果输入方向大于某个阈值，将 faceDirx 和 faceDiry 设置为 1 或 -1
        if (moveDirection.x > 0.1f)
            faceDirx = 3;
        else if (moveDirection.x < -0.1f)
            faceDirx = -3;
        // if (inputDirection.y > 0.1f)
        //     faceDiry = 1;
        // else if (inputDirection.y < -0.1f)
        //     faceDiry = -1;
        // 将本地缩放设置为 faceDirx 和 faceDiry 的值
        transform.localScale = new Vector3(faceDirx, 3, 3);
        animator.SetFloat("MoveX", Mathf.Abs(moveDirection.x));
        animator.SetFloat("MoveY", Mathf.Abs(moveDirection.y));
    }
    
    Vector2 CalculateMoveDirection()
    {
        if (target != null)
        {
            Vector2 targetPosition = target.position;
            Vector2 currentPosition = transform.position;

            // 计算目标方向向量
            Vector2 moveDirection = (targetPosition - currentPosition).normalized;
            return moveDirection;
        }

        return Vector2.zero;
    }
}

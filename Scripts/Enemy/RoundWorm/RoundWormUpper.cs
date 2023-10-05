using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundWormUpper : MonoBehaviour
{
    // 引用父物体
    public GameObject roundPrefab; //敌人的预制体
    public Animator animator;
    private int time1 = 0;
    private int time2 = 0;
    //private bool prevEmergingState = false; // 用于保存前一帧的出现状态
    //private bool prevShootState = false; // 用于保存前一帧的射击状态
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        SetAnimation(); 
    }

    void SetAnimation()
    {
        bool isEmerging = roundPrefab.GetComponent<RoundWorm>().isEmerging;
        bool shoot = roundPrefab.GetComponent<RoundWorm>().shoot;
        if (isEmerging && time1 == 0)
        {   
            time1 = 1;
            animator.SetBool("isEmerging", isEmerging);
        }
        else if(!isEmerging && time1 == 1)
        {   
            time1 = 2;
            animator.SetBool("isEmerging",isEmerging);
        }
        if (shoot && time2 == 0)
        {   
            time2 = 1;
            animator.SetBool("shoot",shoot);
        }
        else if(!shoot && time2 == 1)
        {   
            time2 = 2;
            animator.SetBool("shoot",shoot);
        }//似乎通过time来限制动画播放不太行,再试试喵
    }
}

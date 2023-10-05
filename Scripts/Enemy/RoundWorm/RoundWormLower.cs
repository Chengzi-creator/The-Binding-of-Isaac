using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundWormLower : MonoBehaviour
{
    // 引用父物体
    public GameObject roundPrefab; //敌人的预制体
    public Animator animator;
    //private int time1 = 0;
    //private int time2 = 0;
    private bool prevEmergingState = false; // 用于保存前一帧的出现状态
    
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
        if (isEmerging != prevEmergingState)
        {
            animator.SetBool("isEmerging", isEmerging);
            prevEmergingState = isEmerging;
        }
    }

}

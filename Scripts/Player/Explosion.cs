using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo info;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {   
        //获取动画的播放进度
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }//爆炸完毕后消除爆炸特效
    }
}

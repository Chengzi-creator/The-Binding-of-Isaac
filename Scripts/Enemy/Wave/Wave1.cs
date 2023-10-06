using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//对每一波怪物的定义

[Serializable]
public class Wave1
{
    public Spider spider;
    //public Enemy enemy;
    public int count;//敌人数量
    public float timeBetweenSpawn; //出生间隔
}
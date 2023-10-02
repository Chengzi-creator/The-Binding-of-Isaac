using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rbody;

    public bool isVertical;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        
    }
}

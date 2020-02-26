using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;
    public float attackRange;

    Rigidbody2D rig;
    Animator animator;
    float initX;
    bool towardsRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //if(player in attack size){
        //    attack();
        //}else{
        float x = transform.position.x;
        if (x <= initX - moveRange || x >= initX + moveRange)
        {
            towardsRight = !towardsRight;
        }
        move();
        //}
    }

    void move(){
        rig.velocity = new Vector2(towardsRight?moveSpeed:moveSpeed*-1, rig.velocity.y);
        animator.SetBool("walk_r", towardsRight);
        animator.SetBool("walk_l", !towardsRight);
    }
}

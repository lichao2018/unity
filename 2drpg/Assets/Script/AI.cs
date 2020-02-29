using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;

    Rigidbody2D rig;
    Animator animator;
    float initX;
    bool towardsRight = false;
    bool attacking = false;
    bool startAttack = false;

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
        if(attackAnimating() && startAttack){
            attacking = true;
        }
        if(attacking){
            rig.velocity = new Vector2(0, rig.velocity.y);
            if (!attackAnimating()){
                Debug.Log("stop attack");
                startAttack = false;
                attacking = false;
                animator.SetBool("attack_r", false);
            }
        }else{
            float x = transform.position.x;
            if (x <= initX - moveRange || x >= initX + moveRange)
            {
                towardsRight = !towardsRight;
            }
            move();
        }

        //if (!attackAnimating()){
        //    animator.SetBool("attack_r", false);
        //    float x = transform.position.x;
        //    if (x <= initX - moveRange || x >= initX + moveRange)
        //    {
        //        towardsRight = !towardsRight;
        //    }
        //    move();
        //}
    }

    void move(){
        rig.velocity = new Vector2(towardsRight?moveSpeed:moveSpeed*-1, rig.velocity.y);
        //animator.SetBool("walk_r", towardsRight);
        //animator.SetBool("walk_l", !towardsRight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            //todo player damage
        }
    }

    public void attack(){
        //animator.SetBool("walk_r", false);
        //animator.SetBool("walk_l", false);
        startAttack = true;
        animator.SetBool("attack_r", true);
    }

    bool attackAnimating(){
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return (stateInfo.IsName("enemyAttackLeft") || stateInfo.IsName("enemyAttackRight")) && stateInfo.normalizedTime < 1.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    Rigidbody2D rig;
    Animator animator;
    bool towardsRight = true;

    public float jumpForce = 300;
    public float moveSpeed = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackCtrl()){
            MoveCtrl(true);
            return;
        }
        MoveCtrl(false);
    }

    void MoveCtrl(bool stopMove){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jumpForce));
        }
        if (stopMove){
            rig.velocity = new Vector2(0, rig.velocity.y);
            return;
        }
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        rig.velocity = new Vector2(horizontal, rig.velocity.y);

        if (horizontal > 0.01f)
        {
            towardsRight = true;
            MoveAnimator(false, true);
        }
        else if (horizontal < -0.01f)
        {
            towardsRight = false;
            MoveAnimator(true, false);
        }
        else
        {
            MoveAnimator(false, false);
        }
    }

    void MoveAnimator(bool left, bool right){
        animator.SetBool("walking_l", left);
        animator.SetBool("walking_r", right);
    }

    bool AttackCtrl(){
        //如果攻击结束，则显示idle动画
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("playerAttackLeft") 
           && !animator.GetCurrentAnimatorStateInfo(0).IsName("playerAttackRight"))
        {
            Attack(false);
        }else{
            return true;
        }
        if(Input.GetKeyDown(KeyCode.J)){
            Attack(true);
            return true;
        }
        return false;
    }

    void Attack(bool attack){
        MoveAnimator(false, false);
        animator.SetBool(towardsRight ? "attack_r" : "attack_l", attack);
    }
}

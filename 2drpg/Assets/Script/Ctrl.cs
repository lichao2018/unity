using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    Rigidbody2D rig;
    Animator animator;

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
        MoveCtrl();
    }

    void MoveCtrl(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jumpForce));
        }
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        rig.velocity = new Vector2(horizontal, rig.velocity.y);

        if (horizontal > 0.01f)
        {
            animator.SetBool("walking_r", true);
            animator.SetBool("walking_l", false);
        }
        else if (horizontal < -0.01f)
        {
            animator.SetBool("walking_r", false);
            animator.SetBool("walking_l", true);
        }
        else
        {
            animator.SetBool("walking_l", false);
            animator.SetBool("walking_r", false);
        }
    }

    void AttackCtrl(){

    }
}

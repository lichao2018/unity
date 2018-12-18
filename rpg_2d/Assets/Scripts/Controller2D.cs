using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour {
    CharacterController characterController;
    public float gravity = 10;
    public float walkSpeed = 5;
    public float jumpHeight = 5;
    float takenDamage = 0.2f;
    Vector3 moveDirection = Vector3.zero;
    float horizontal = 0;

    public Rigidbody bulletPrefab;
    float attackRate = 0.5f;
    float cooldown;
    bool lookRight = true;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        characterController.Move(moveDirection * Time.deltaTime);
        horizontal = Input.GetAxis("Horizontal");
        moveDirection.y -= gravity * Time.deltaTime;
        if(horizontal == 0){
            moveDirection.x = horizontal;
        }
        if(horizontal > 0.01f){
            lookRight = true;
            moveDirection.x = horizontal * walkSpeed;
        }
        if(horizontal < -0.01f){
            lookRight = false;
            moveDirection.x = horizontal * walkSpeed;
        }
        if(characterController.isGrounded){
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.K)){
                moveDirection.y = jumpHeight;
            }
        }

        if (Time.time >= cooldown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                BulletAttack();
            }
        }
    }

    void BulletAttack()
    {
        Rigidbody bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
        bPrefab.GetComponent<Rigidbody>().AddForce(Vector3.right * 500 * (lookRight ? 1 : -1));
        cooldown = Time.time + attackRate;
    }

    public IEnumerator TakenDamage(){
        Renderer render = GetComponent<Renderer>();
        render.enabled = false;
        yield return new WaitForSeconds(takenDamage);
        render.enabled = true;
        yield return new WaitForSeconds(takenDamage);
        render.enabled = false;
        yield return new WaitForSeconds(takenDamage);
        render.enabled = true;
        yield return new WaitForSeconds(takenDamage);
        render.enabled = false;
        yield return new WaitForSeconds(takenDamage);
        render.enabled = true;
        yield return new WaitForSeconds(takenDamage);
    }
}

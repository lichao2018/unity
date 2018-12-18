using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour {
    public GameManager gameManager;
    float startPos;
    float endPos;
    public int utilsToMove = 5;
    public int moveSpeed = 2;
    bool moveRight = true;

    int enemyHealth = 1;
    public bool basicEnemy;
    public bool advancedEnemy;


    private void Awake()
    {
        startPos = transform.position.x;
        endPos = startPos + utilsToMove;
        if(basicEnemy){
            enemyHealth = 3;
        }
        if(advancedEnemy){
            enemyHealth = 6;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody enemyRigidbody = GetComponent<Rigidbody>();
        if(moveRight){
            enemyRigidbody.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if(enemyRigidbody.position.x >= endPos){
            moveRight = false;
        }
        if(!moveRight){
            enemyRigidbody.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }
        if(enemyRigidbody.position.x <= startPos){
            moveRight = true;
        }
	}

    int damageValue = 1;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            gameManager.controller2D.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
        }
    }

    void EnemyDamaged(int damage){
        if(enemyHealth > 0){
            enemyHealth -= damage;
        }
        if(enemyHealth <= 0){
            gameManager.curEXP += 10;
            enemyHealth = 0;
            Destroy(gameObject);
        }
    }
}

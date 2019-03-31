using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float rotateSpeed;
    public float moveSpeed;
    public GameObject explosionEnemy;
    public GameObject explosionPlayer;
    private GameManager gameManager;
    public int score;
    float life;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotateSpeed;
        GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -1) * moveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= gameManager.boundary.xMin){
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -1) * moveSpeed;
        }else if(transform.position.x >= gameManager.boundary.xMax){
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -1) * moveSpeed;
        }
        if(transform.position.z <= gameManager.boundary.zMin){
            Vector3 position = new Vector3(transform.position.x, 0, gameManager.boundary.zMax);
            transform.position = position;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet"){
            Destroy(other.gameObject);
            Instantiate(explosionEnemy, transform.position, transform.rotation);
            life -= other.gameObject.GetComponent<BulletController>().firePower;
            if (life <= 0)
            {
                gameManager.AddCoin(score);
                Destroy(gameObject);
            }
        }
        if(other.tag == "Player"){
            gameManager.GameOver();
            Instantiate(explosionPlayer, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void setLife(float value){
        life = value;
    }
}

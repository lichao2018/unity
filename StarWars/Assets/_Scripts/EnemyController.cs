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
        if(other.tag == "Player"){
            gameManager.GameOver();
            Instantiate(explosionPlayer, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }else{
            //fixme 使OrangeShell继承BulletController，以解决下面bullet和GreenBall用的使BulletController，OrangeShell用的是OrangeShell的问题
            //BulletController bulletController = other.gameObject.GetComponent<BulletController>();
            //OrangeShell bulletController = other.gameObject.GetComponent<OrangeShell>();
            BulletBase bulletController = other.gameObject.GetComponent<BulletBase>();
            Instantiate(explosionEnemy, transform.position, transform.rotation);
            if (other.tag == "Bullet")
            {
                Destroy(other.gameObject);
                life -= bulletController.firePower;
                if (life <= 0)
                {
                    gameManager.AddCoin(score);
                    Destroy(gameObject);
                }
            }
            if (other.tag == "GreenBall")
            {
                if(life > bulletController.firePower){
                    life -= bulletController.firePower;
                    Destroy(other.gameObject);
                }
                else if(life < bulletController.firePower){
                    bulletController.firePower -= life;
                    gameManager.AddCoin(score);
                    Destroy(gameObject);
                }
                else{
                    Destroy(other.gameObject);
                    gameManager.AddCoin(score);
                    Destroy(gameObject);
                }
            }
            if(other.tag == "OrangeShell"){
                Destroy(other.gameObject);
                if (life > bulletController.firePower)
                {
                    life -= bulletController.firePower;
                }
                else
                {
                    gameManager.AddCoin(score);
                    Destroy(gameObject);
                }
            }
        }
    }

    public void SetLife(float value){
        life = value;
    }
}

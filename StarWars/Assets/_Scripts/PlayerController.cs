using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float fireRate;
    private float nextFire;
    public Transform shootSpawn;
    public GameObject bullet;
    public float firePower;

    // Use this for initialization
    void Start () {
        fireRate = MenuManager.GetInstance().weaponFireRate;
        firePower = MenuManager.GetInstance().weaponPower;
    }
	
	// Update is called once per frame
	void Update () {
        Fire();
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move(){
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movementHorizontal, 0, movementVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
    }

    private void Fire(){
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bulletObj = Instantiate(bullet, shootSpawn.position, shootSpawn.rotation);
            bulletObj.GetComponent<BulletController>().SetPower(firePower);
        }
    }

    public void FireRateLvUp(float value){
        fireRate += value;
    }

    public void FirePowerLvUp(float power){
        firePower += power;
    }
}

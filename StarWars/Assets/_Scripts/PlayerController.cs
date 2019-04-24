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

    private Vector3 touchposition;
    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;

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
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }
        if (isMouseDown)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                transform.position = transform.position + offset;
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void Fire(){
        if (Time.time > nextFire)
        {
            nextFire = Time.time + (1/fireRate);
            GameObject bulletObj = Instantiate(bullet, shootSpawn.position, shootSpawn.rotation);
            bulletObj.GetComponent<BulletController>().SetPower(firePower);
        }
    }
}

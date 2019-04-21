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

    private Vector3 MousePositionLast;//用于计算移动方向的起始位置
    private Vector3 MousePositionNew;//用于计算移动方向的结尾位置
    private Vector3 MouseMoveDirection;//用于表示移动方向
    private Vector3 MouseWorldMoveDirection;//用于在世界坐标系里移动某物体的方向向量

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
        MousePositionLast = MousePositionNew;
        MousePositionNew = Input.mousePosition;
        MouseMoveDirection = MousePositionNew - MousePositionLast; //用两个坐标相减，得出鼠标的移动方向向量

        MouseWorldMoveDirection = new Vector3(MouseMoveDirection.x, 0, MouseMoveDirection.y);
        GetComponent<Rigidbody>().velocity = MouseWorldMoveDirection;
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

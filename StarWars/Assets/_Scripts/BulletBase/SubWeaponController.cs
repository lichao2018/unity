using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SubWeaponController : MonoBehaviour {
    public GameObject bulletPrab;
    public float fireRate;
    public bool firstBorn;
    private float nextFire;

	// Use this for initialization
    void Start () {
        switch(MenuManager.GetInstance().currentSubWeapon){
            case MenuManager.SubWeapon.GreenBall:
                bulletPrab = (GameObject)Resources.Load("GreenBall");
                break;
            case MenuManager.SubWeapon.OrangeShell:
                bulletPrab = (GameObject)Resources.Load("OrangeShell");
                break;
            case MenuManager.SubWeapon.Lightning:
                bulletPrab = (GameObject)Resources.Load("Lightning");
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            float scope = 0;
            float power = 0;
            if (firstBorn)
            {
                if (MenuManager.GetInstance().currentSubWeapon == MenuManager.SubWeapon.Lightning)
                {
                    scope = MenuManager.GetInstance().lightningScope;
                    power = MenuManager.GetInstance().lightningPower;
                    GameObject player = GameObject.Find("Player");
                    Vector3 position = player.transform.position;
                    position.z += 8;
                    GameObject bullet = Instantiate(bulletPrab, position, Quaternion.identity);
                    Vector3 bulletScale = bullet.transform.localScale;
                    bullet.transform.localScale = new Vector3(
                            bulletScale.x * scope,
                            bulletScale.y,
                            bulletScale.z * scope);
                    bullet.GetComponent<BulletBase>().SetPower(power);
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrab, transform.position, transform.rotation);
                    Vector3 bulletScale = bullet.transform.localScale;
                    switch (MenuManager.GetInstance().currentSubWeapon)
                    {
                        case MenuManager.SubWeapon.GreenBall:
                            scope = MenuManager.GetInstance().greenBallScope;
                            power = MenuManager.GetInstance().greenBallPower;
                            break;
                        case MenuManager.SubWeapon.OrangeShell:
                            scope = MenuManager.GetInstance().orangeShellScope;
                            power = MenuManager.GetInstance().orangeShellPower;
                            break;
                    }
                    bullet.transform.localScale = new Vector3(
                        bulletScale.x * scope,
                        bulletScale.y,
                        bulletScale.z * scope);
                    bullet.GetComponent<BulletBase>().SetPower(power);
                }
            }
            firstBorn = !firstBorn;
        }
    }
}

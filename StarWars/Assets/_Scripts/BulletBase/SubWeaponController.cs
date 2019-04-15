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
            if (firstBorn)
            {
                GameObject bullet = Instantiate(bulletPrab, transform.position, transform.rotation);
                Vector3 bulletScale = bullet.transform.localScale;
                float scope = 0;
                float power = 0;
                switch(MenuManager.GetInstance().currentSubWeapon){
                    case MenuManager.SubWeapon.GreenBall:
                        scope = MenuManager.GetInstance().greenBallScope;
                        power = MenuManager.GetInstance().greenBallPower;
                        break;
                    case MenuManager.SubWeapon.OrangeShell:
                        scope = MenuManager.GetInstance().orangeShellScope;
                        power = MenuManager.GetInstance().orangeShellPower;
                        break;
                    case MenuManager.SubWeapon.Lightning:
                        scope = MenuManager.GetInstance().lightningScope;
                        power = MenuManager.GetInstance().lightningPower;
                        break;
                }
                bullet.transform.localScale = new Vector3(
                    bulletScale.x * scope,
                    bulletScale.y,
                    bulletScale.z * scope);
                bullet.GetComponent<BulletBase>().SetPower(power);
            }
            firstBorn = !firstBorn;
        }
    }
}

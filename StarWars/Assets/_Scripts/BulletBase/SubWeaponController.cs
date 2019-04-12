using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeaponController : MonoBehaviour {
    public GameObject bulletPrab;
    public float fireRate;
    public bool firstBorn;
    private float nextFire;

	// Use this for initialization
    void Start () {
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
                bullet.transform.localScale = new Vector3(
                    bulletScale.x * MenuManager.GetInstance().subWeaponScope,
                    bulletScale.y,
                    bulletScale.z * MenuManager.GetInstance().subWeaponScope);
                bullet.GetComponent<BulletBase>().SetPower(MenuManager.GetInstance().subWeaponPower);
            }
            firstBorn = !firstBorn;
        }
    }
}

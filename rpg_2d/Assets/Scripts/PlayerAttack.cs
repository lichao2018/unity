using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public Rigidbody bulletPrefab;
    float attackRate = 0.5f;
    float cooldown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= cooldown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                BulletAttack();
            }
        }
	}

    void BulletAttack(){
        Rigidbody bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
        bPrefab.GetComponent<Rigidbody>().AddForce(Vector3.right * 500);
        cooldown = Time.time + attackRate;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : EnemyBase {

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -1) * moveSpeed;
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}

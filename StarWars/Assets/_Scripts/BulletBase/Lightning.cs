using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : BulletBase {

	// Use this for initialization
	void Start () {
        firePower = 5;
        Destroy(gameObject, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

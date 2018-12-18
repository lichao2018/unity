using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    int damageValue = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Destroy(gameObject, 1.25f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy"){
            Destroy(gameObject);
            col.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
        }
    }
}

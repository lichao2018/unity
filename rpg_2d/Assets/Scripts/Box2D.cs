using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            print("collid player");
            transform.Translate(new Vector3(collision.gameObject.transform.position.x, transform.position.y, transform.position.z));
        }
    }
}

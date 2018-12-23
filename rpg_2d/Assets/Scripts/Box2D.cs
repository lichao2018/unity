using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2D : MonoBehaviour {
    bool pushed = false;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float dist = player.transform.position.x - transform.position.x;
        if(Mathf.Abs(dist) <= 1.3 && Input.GetKey(KeyCode.LeftControl) && player.transform.position.y < 1.1)
        {
            if(dist < 0)
            {
                transform.position = new Vector3(player.transform.position.x + 1.3f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x - 1.3f, transform.position.y, transform.position.z);
            }
        }
	}
}

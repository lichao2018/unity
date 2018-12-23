using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2D : MonoBehaviour {
    bool lifted = false;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //扔箱子
        if (Input.GetKeyDown(KeyCode.J))
        {
            lifted = false;
        }
        float distX = player.transform.position.x - transform.position.x;
        if(Mathf.Abs(distX) <= 1.3 && player.transform.position.y < 1.1)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                //举箱子
                if (Input.GetKeyDown(KeyCode.J))
                {
                    lifted = true;
                }
                //推箱子
                if (distX < 0)
                {
                    transform.position = new Vector3(player.transform.position.x + 1.3f, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(player.transform.position.x - 1.3f, transform.position.y, transform.position.z);
                }
            }
        }
        if (lifted)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, transform.position.z);
            transform.parent = player.transform;
        }
        else
        {
            if(transform.parent == player.transform)
            {
                transform.position = new Vector3(player.transform.position.x + 1.3f, 1, transform.position.z);
                transform.parent = null;
            }
        }
	}
}

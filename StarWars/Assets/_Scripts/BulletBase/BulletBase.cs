using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour {
    public float speed;
    public float firePower;
    protected GameManager gameManager;

    // Use this for initialization
    protected void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	public void Update () {
        if (transform.position.z > gameManager.boundary.zMax)
        {
            Destroy(gameObject);
        }
    }

    public void SetPower(float power)
    {
        firePower = power;
    }
}

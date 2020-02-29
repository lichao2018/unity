﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    AI ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponentInParent<AI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && ai != null){
            ai.attack();
        }
    }
}

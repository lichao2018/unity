using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeShell : BulletBase {

    // Use this for initialization
    new void Start()
    {
        base.Start();
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    new void Update()
    {
    }
}

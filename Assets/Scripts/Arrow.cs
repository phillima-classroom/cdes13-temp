using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D _arrowRb;
    
    void Awake()
    {
        _arrowRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _arrowRb.velocity = new Vector2(2,0);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D _arrowRb;

    [SerializeField]
    float arrowSpeed;

    //C#
    public int ArrowDir { get; set; } = 1;

    void Awake()
    {
        _arrowRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _arrowRb.velocity = new Vector2(arrowSpeed*ArrowDir,0);
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Destroy(other.gameObject);
    // }
}
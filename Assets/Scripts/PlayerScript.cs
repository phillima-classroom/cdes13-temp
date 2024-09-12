using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    
    Rigidbody2D _playerRb;

    Vector2 horMov;
    
    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }


    void MovePlayer()
    {
        _playerRb.velocity = new Vector2(horMov.x * 5,_playerRb.velocity.y);
    }
    
    void OnMove(InputValue inputValue)
    {
        horMov = inputValue.Get<Vector2>();
    }

    void OnJump(InputValue inputValue)
    {
        print("pulou");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}

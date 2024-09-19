using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class PlayerScript : MonoBehaviour
{
    Animator _playerAnimator;
    Rigidbody2D _playerRb;
    Vector2 horMov;

    [SerializeField]
    float horSpeed;
    
    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    void MovePlayer()
    {
        _playerRb.velocity = new Vector2(horMov.x * horSpeed,_playerRb.velocity.y);

        bool isRunning = Mathf.Abs(_playerRb.velocity.x) > Mathf.Epsilon;
        _playerAnimator.SetBool(Constantes.ANIM_IS_RUNNING,isRunning);
        if (isRunning)
        {
            Flip();
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(Mathf.Sign(_playerRb.velocity.x),1,1);
    }
    
    void OnMove(InputValue inputValue)
    {
        horMov = inputValue.Get<Vector2>();
    }

    void OnJump(InputValue inputValue)
    {
        _playerRb.velocity = new Vector2(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}

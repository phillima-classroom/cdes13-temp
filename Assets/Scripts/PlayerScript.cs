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
    BoxCollider2D _feetCollider;

    [SerializeField]
    GameObject arrowPrefab;

    [SerializeField]
    GameObject playerShootPos;
    
    [SerializeField]
    float horSpeed;
    
    [SerializeField]
    float jumpSpeed;
    
    bool canDoubleJump;
    
    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _feetCollider = GetComponent<BoxCollider2D>();
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
        //CHECAR SE ESTA NO CHAO
        if (_feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _playerRb.velocity = new Vector2(0, jumpSpeed);
            canDoubleJump = true;
        }else if (canDoubleJump)
        {
            _playerRb.velocity = new Vector2(0, jumpSpeed);
            canDoubleJump = false;  
        }
    }

    void OnFire(InputValue inputValue)
    {
        //Criar o arrow
        _playerAnimator.SetTrigger("Shoot");
        
        GameObject arrow = Instantiate(
            arrowPrefab,
            playerShootPos.transform.position,
            Quaternion.identity);

        float xScale = Mathf.Sign(transform.localScale.x);
        
        arrow.transform.localScale = new Vector3(xScale, 1, 1);
        arrow.GetComponent<Arrow>().ArrowDir = (int) xScale;
    }
    

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
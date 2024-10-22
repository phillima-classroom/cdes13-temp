using System;
using UnityEngine;
using Utils;

public class Enemy : MonoBehaviour
{
    Rigidbody2D _enemyRb;

    [SerializeField]
    float horSpeed;

    [SerializeField] 
    GameObject poofVFX;
    
    void Awake()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimento();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Constantes.TAG_Foreground))
        {
            horSpeed = -horSpeed;
            transform.localScale = new Vector3(Mathf.Sign(horSpeed),1,1);
        }
        
    }
    
    void Movimento()
    {
        _enemyRb.velocity = new Vector2(horSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Arrow>() != null)
        {
            AudioSource.PlayClipAtPoint(
                GetComponent<AudioSource>().clip,
                transform.position);
            GameObject poofGO = Instantiate(poofVFX, transform.position, Quaternion.identity);
            Destroy(poofGO,2.0f);
            Destroy(gameObject,0.1f);
        }
    }
}
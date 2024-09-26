using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D _enemyRb;

    [SerializeField]
    float horSpeed;

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
        horSpeed = -horSpeed;
        transform.localScale = new Vector3(Mathf.Sign(horSpeed),1,1);
    }
    
    void Movimento()
    {
        _enemyRb.velocity = new Vector2(horSpeed, 0);
    }
}
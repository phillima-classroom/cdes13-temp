using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool _isBeingDestroyed;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isBeingDestroyed)
        {
            _isBeingDestroyed = true;
            AudioSource.PlayClipAtPoint(
                GetComponent<AudioSource>().clip
                ,transform.position);

            FindObjectOfType<ScoreUI>().UpdateScore();
            Destroy(gameObject);
  
        }
    }
}

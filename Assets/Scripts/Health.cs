using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    
    public Color flashColor;
    public GameObject deathEffect;
    private Material _material;
    private Shake _shake;

    // Start is called before the first frame update
    void Start()
    {
        _material = gameObject.GetComponent<SpriteRenderer>().material;
        _shake = GameObject.FindGameObjectWithTag("ShakeManager").GetComponent<Shake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            health--;

            if (health > 0)
            {
                FindObjectOfType<AudioManager>().Play("EnemyHit");
                _material.color = flashColor;
                Invoke(nameof(ResetMaterial), 0.15f);
            }
            else
            {
                _material.color = flashColor;
                _shake.CameraShake();
                FindObjectOfType<AudioManager>().Play("EnemyDeath");
                
                GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
                Destroy(gameObject, 0.2f);
            }
        } 
    }

    private void ResetMaterial()
    {
        _material.color = Color.white;
    }
}
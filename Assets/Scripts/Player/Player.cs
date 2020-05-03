using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int candyCounter;
    public float moveSpeed;
    private bool _isMoving;
    private int _health = 4;
    private bool _makesBackpackBigger;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject backpack;
    public Slider slider;
    private Material _playerMaterial;
    private Material _backpackMaterial;
    public Color flashColor;
    public GameObject deathScreen;
    public SpriteRenderer playerSprite;
    public SpriteRenderer backpackSprite;
    public TextMeshProUGUI candyCounterText;

    private Vector2 _movement;
    private Vector2 _lookDir;

    private void Start()
    {
        _playerMaterial = playerSprite.material;
        _backpackMaterial = backpackSprite.material;
    }

    private void Update()
    {
        // Handles movement inputs
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(_movement.x) > 0 || Mathf.Abs(_movement.y) > 0)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        animator.SetBool("isMoving", _isMoving);
        animator.SetFloat("moveX", _movement.x);
        animator.SetFloat("moveY", _movement.y);
        
        if (_movement.x > 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }

        if (_movement.y > 0)
        {
            backpackSprite.sortingOrder = 10;
        }
        else
        {
            backpackSprite.sortingOrder = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * moveSpeed * Time.fixedDeltaTime); // Moves the player
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            SubtractHealth();
        }
    }

    private void PickUpCandy(bool value)
    {
        AddHealth();
        FindObjectOfType<AudioManager>().Play("CoinPickUp");

        _makesBackpackBigger = value;
        candyCounter++;
        HighscoreManager.CurrentCandyCount++;
        
        transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z);
        Invoke(nameof(UpdateBackpackSize), 0.2f);
        UpdateCandyCounterText();
    }

    private void UpdateCandyCounterText()
    {
        candyCounterText.text = candyCounter.ToString();
    }

    private void UpdateBackpackSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z);

        if (_makesBackpackBigger)
        {
            float sizeIncrease = candyCounter / 50f;
            backpack.transform.localScale += new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);   
        }
    }

    private void AddHealth()
    {
        if (_health < 4)
        {
            _health++;
            slider.value = _health;   
        }
    } 

    private void SubtractHealth()
    {
        _health--;
        slider.value = _health;
        GameObject.FindGameObjectWithTag("ShakeManager").GetComponent<Shake>().CameraShake();
        
        if (_health > 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            _playerMaterial.color = flashColor;
            _backpackMaterial.color = flashColor;
            Invoke(nameof(ResetMaterial), 0.15f);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Time.timeScale = 0;
            deathScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
    
    private void ResetMaterial()
    {
        _backpackMaterial.color = Color.white;
        _playerMaterial.color = Color.white;
    }
}

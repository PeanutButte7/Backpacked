using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //public AudioManager audioManager;
    
    public Transform firepoint;
    public GameObject bulletPrefab;
    public Camera cam;
    public GameObject gun;
    private SpriteRenderer _gunSpirte;
    public float timeBtwShots;
    private float _currentTimeBtwShots;

    private Vector2 _mousePos;
    private Vector2 _lookDir;

    public float bulletForce = 5f;

    private void Start()
    {
        _gunSpirte = gun.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets mouse position
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //crosshair.transform.position = _mousePos;

        // Gets direction mouse is pointing at from firepoint and sets the rotation to firepoint
        Vector2 direction = new Vector2(_mousePos.x - firepoint.position.x, _mousePos.y - firepoint.position.y);
        firepoint.up = direction;

        if (direction.x > 0)
        {
            _gunSpirte.flipY = true;
        }
        else
        {
            _gunSpirte.flipY = false;
        }
        
        
        if (_currentTimeBtwShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                _currentTimeBtwShots = timeBtwShots;
            }
        }
        else
        {
            _currentTimeBtwShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        //audioManager.Play("PlayerShoot");
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
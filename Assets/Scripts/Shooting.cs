using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Shooting : MonoBehaviour
{
    public Transform raycastPoint;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce;
    public float timeBtwShots;
    private float _currentTimeBtwShots;


    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        
        // Rotates firepoint toward the target
        firePoint.up = target.position - firePoint.position;

        if (_currentTimeBtwShots <= 0)
        {
            // Draw a line to a player
            RaycastHit2D hit = Physics2D.Linecast(raycastPoint.position, target.position, ~1 << LayerMask.NameToLayer("Enemy"));
            //Debug.DrawLine(raycastPoint.position, target.position, Color.magenta, 5f, false);
            
            // If the path is clear then shoot
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<AIPath>().enabled = true;
                Invoke(nameof(Shoot), 0.2f);
                _currentTimeBtwShots = timeBtwShots;
            }
        }
        else
        {
            _currentTimeBtwShots -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
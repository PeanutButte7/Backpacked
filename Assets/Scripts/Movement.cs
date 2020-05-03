using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform target;
    public Animator animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;

    private float _moveX;
    private float _moveY;
    private bool _isMoving;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        
        _moveX = target.position.x - transform.position.x;
        _moveY = target.position.y - transform.position.y;
        
        animator.SetFloat("moveX", _moveX);
        animator.SetFloat("moveY", _moveY);

        if (_moveX > 0)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (_rb.IsSleeping())
        {
            _isMoving = false;
        }
        else
        {
            _isMoving = true;
        }
        
        animator.SetBool("isMoving", _isMoving);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private bool _pickUpAllowed;
    public bool makesBackpackBigger = true;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _pickUpAllowed = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        _player.SendMessage("PickUpCandy", makesBackpackBigger);
        Destroy(gameObject);
    }
}

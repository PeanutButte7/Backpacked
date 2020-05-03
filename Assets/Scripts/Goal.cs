using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool _pickUpAllowed;
    
    public GameObject uiManager;

    // Update is called once per frame
    void Update()
    {
        if (_pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
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

    private void EndGame()
    {
        uiManager.SendMessage("ShowEndScreen", false);
    }
}

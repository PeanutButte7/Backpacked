using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
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
        uiManager.SendMessage("ShowDialogue", "Cake is a lie");
    }
}

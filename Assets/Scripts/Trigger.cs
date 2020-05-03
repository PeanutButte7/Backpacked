using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject uiManager;
    public string text;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.SendMessage("ShowDialogue", text);
            Destroy(gameObject);
        }
    }
}

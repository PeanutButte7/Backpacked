using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameUiManager : MonoBehaviour
{
    public GameObject goalScreen;
    public GameObject endScreen;
    public TextMeshProUGUI stopwatchText;
    public TextMeshProUGUI currentScoreText;
    public GameObject dialogue;
    public TextMeshProUGUI dialogueText;
    
    public float stopwatch;

    private void Update()
    {
        stopwatch += Time.deltaTime;

        if (stopwatchText != null)
        {
            stopwatchText.text = "Seconds: " + Math.Round(stopwatch, 2);   
        }
        
        if (dialogue.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
            HideDialogue();
        }
    }

    public void ShowDialogue(string myText)
    {
        Time.timeScale = 0;
        dialogue.SetActive(true);
        StartCoroutine(Type(myText));
    }

    private void HideDialogue()
    {
        Time.timeScale = 1;
        dialogue.SetActive(false);
        dialogueText.text = "";
    }

    IEnumerator Type(string myText)
    {
        for (int i = 0; i <= myText.Length; i++)
        {
            dialogueText.text = myText.Substring(0, i);
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }

    public void ShowEndScreen()
    {
        Time.timeScale = 0;
        HighscoreManager.CalculateScore(stopwatch);
        currentScoreText.text = "Your score is " + HighscoreManager.LastScore;
        endScreen.SetActive(true);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

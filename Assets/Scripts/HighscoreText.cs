using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Highscore: " + HighscoreManager.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

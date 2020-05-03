using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighscoreManager
{
    public static float Score;
    public static float CurrentScore;
    public static int CurrentCandyCount;
    public static float LastScore;

    public static void CalculateScore(float stopwatch)
    {
        // calculates current score
        double time = Math.Round(stopwatch, 2);
        CurrentScore = (float) Math.Round(CurrentCandyCount - time / 100, 2);
        CurrentScore *= 100;

        // checks if its bigger that highscore
        if (CurrentScore >= Score)
        {
            Score = CurrentScore;
        }
        
        // resets scores
        LastScore = CurrentScore;
        CurrentCandyCount = 0;
        CurrentScore = 0;
    }
}

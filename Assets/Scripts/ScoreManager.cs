using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviourSingletonPersistent<ScoreManager>
{
    private const int MaxScores = 10;

    private int[] highScores = new int[MaxScores];

    public int[] HighScores => highScores;

    public void AddScore(int score)
    {
        bool added = false;

        for (int i = 0; i < highScores.Length; i++)
        {
            if (score > highScores[i])
            {
                Array.Copy(highScores, i, highScores, i + 1, highScores.Length - 1 - i);
                highScores[i] = score;
                added = true;
                break;
            }
        }

        if (!added && highScores[MaxScores - 1] < score)
        {
            return;
        }

        Array.Resize(ref highScores, MaxScores);
    }
}
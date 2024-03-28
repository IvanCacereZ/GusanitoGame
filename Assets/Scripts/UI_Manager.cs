using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Camera mainCamera;
    public Text scoreText;
    public Text hightScoreText;
    void Start()
    {
        UpdateCameraSize();
        hightScoreText.text = "HightScore: " + ScoreManager.Instance.HighScores[0];
    }
    private void Update()
    {
        UpdateScore();
    }
    void UpdateCameraSize()
    {
        float newSize = CalculateCameraSize((int)(GameManager.Instance.MapDistance.x)*2);
        mainCamera.orthographicSize = newSize;
    }

    float CalculateCameraSize(int numberOfBlocks)
    {
        float sizeFor16Blocks = 5.058825f;
        float newSize = sizeFor16Blocks * (numberOfBlocks / 16f);

        return newSize;
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.Instance.ActualScore;
    }
}
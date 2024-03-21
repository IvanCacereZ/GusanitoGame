using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        UpdateCameraSize();
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 MapDistance;
    public float velocityPlayer;
    public GameObject prefabBody;
    public bool GameEnded = false;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public float GetLimits(char coord)
    {
        int LimitX = (int) MapDistance.x/2;
        int LimitY = (int) MapDistance.y/2;
        switch (coord)
        {
            case 'x':
                int numeroAleatorioX = Random.Range(-1*LimitX, LimitX + 1);
                return numeroAleatorioX + 0.5f;
            case 'y':
                int numeroAleatorioY = Random.Range(-1 * LimitY, LimitY + 1);
                return numeroAleatorioY + 0.5f;
            default:
                return 0;
        }
    }
}

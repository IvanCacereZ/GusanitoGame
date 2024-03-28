using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public Vector2 MapDistance;
    public float velocityPlayer;
    public GameObject prefabBody;
    public bool GameEnded = false;
    public int ActualScore = 0;
    void Start()
    {
        CalculateY();
    }
    private void Update()
    {
        if (GameEnded)
        {
            ScoreManager.Instance.AddScore(ActualScore);
            SceneLoader loader = new();
            loader.LoadSceneIndex(2);
        }
    }
    public float GetLimits(char coord)
    {
        int LimitX = (int)MapDistance.x / 2;
        int LimitY = (int)MapDistance.y / 2;
        switch (coord)
        {
            case 'x':
                int numeroAleatorioX = Random.Range(-1 * LimitX, LimitX + 1);
                return numeroAleatorioX + 0.5f;
            case 'y':
                int numeroAleatorioY = Random.Range(-1 * LimitY, LimitY + 1);
                return numeroAleatorioY + 0.5f;
            default:
                return 0;
        }
    }

    private void CalculateY()
    {
        if (MapDistance.x % 2 == 0)
        {
            MapDistance.y = MapDistance.x / 2;
        }
        else
        {
            MapDistance.y = (MapDistance.x + 1) / 2;
        }
    }
}

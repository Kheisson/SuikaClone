using UnityEngine;

public class GameController : MonoBehaviour
{
    private BallManager _ballManager;
    private BallSpawner _ballSpawner;
    public static GameController Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        _ballManager = Resources.Load<BallManager>(nameof(BallManager));
        _ballSpawner = new BallSpawner(_ballManager);
        SpawnInitialBall();
    }
    
    private void SpawnInitialBall()
    {
        SpawnBall();
    }
    
    private void SpawnBallImpl()
    {
        _ballSpawner.SpawnBall();
    }
    
    public void SpawnBall()
    {
        //Add a short delay before spawning the ball
        Invoke(nameof(SpawnBallImpl), 0.5f);
    }
    
    public void SpawnBallWithScore(int score, Vector3 position1, Vector3 position2)
    {
        _ballSpawner.SpawnBallWithScore(score, position1, position2);
    }
}
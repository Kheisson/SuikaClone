using UnityEngine;

public class BallSpawner
{
    private readonly BallManager _ballManager;
    private const string BALL_TAG = "Ball";

    public BallSpawner(BallManager ballManager)
    {
        _ballManager = ballManager;
    }
    
    public void SpawnBall()
    {
        var ballData = GetRandomBallData();

        CreateBallGameObject(ballData);
    }

    private BallData GetRandomBallData()
    {
        return _ballManager.GetBallData();
    }

    private Ball CreateBallGameObject(BallData ballData)
    {
        var newBall = new GameObject(BALL_TAG)
        {
            tag = BALL_TAG,
        };

        newBall.AddComponent<SpriteRenderer>();
        newBall.AddComponent<CircleCollider2D>();
        newBall.AddComponent<Rigidbody2D>().isKinematic = true;
        var ball = newBall.AddComponent<Ball>();
        ball.Initialize(ballData);
                                                    
        return ball;
    }
    
    public void SpawnBallWithScore(int score, Vector3 position1, Vector3 position2)
    {
        var ballData = GetBallDataByScore(score);

        var newBall = CreateBallGameObject(ballData);
        newBall.Release();
        SetBallPosition(newBall, position1, position2);
    }
    
    private BallData GetBallDataByScore(int score)
    {
        return _ballManager.GetBallDataByScore(score);
    }
    
    private void SetBallPosition(Ball newBall, Vector3 position1, Vector3 position2)
    {
        var ballPosition = (position1 + position2) / 2;
        newBall.transform.position = ballPosition;
    }
}
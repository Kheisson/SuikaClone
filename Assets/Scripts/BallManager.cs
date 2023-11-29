using UnityEngine;

[CreateAssetMenu(fileName = "New BallManager", menuName = "Ball Manager", order = 52)]
public class BallManager : ScriptableObject
{
    [SerializeField] private BallData[] _ballDataArray;

    public BallData GetBallData()
    {
        var randomIndex = Random.Range(0, _ballDataArray.Length);
        return _ballDataArray[randomIndex];
    }
    
    public BallData GetBallDataByScore(int score)
    {
        var ballData = _ballDataArray[0];
        foreach (var ball in _ballDataArray)
        {
            if (ball.Score == score)
            {
                ballData = ball;
            }
        }

        return ballData;
    }
}
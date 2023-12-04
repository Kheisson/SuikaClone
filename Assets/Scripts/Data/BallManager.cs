using UnityEngine;
namespace Data
{
    [CreateAssetMenu(fileName = "New BallManager", menuName = "Ball Manager", order = 52)]
    public class BallManager : ScriptableObject
    {
        #region --- Inspector ---
        
        [SerializeField] private BallData[] _ballDataArray;
        
        #endregion
        
        
        #region --- Constants ---
        
        private const int BALL_SPAWN_MAX_INDEX = 5;  // This determines the max type of ball to be spawned
    
        #endregion
        
        
        #region --- Public Methods ---
        
        public BallData GetBallData()
        {
            var randomIndex = Random.Range(0, BALL_SPAWN_MAX_INDEX);
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
        
        #endregion
    }
}
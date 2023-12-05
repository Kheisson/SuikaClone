using System.Collections.Generic;
using System.Linq;
using Data;
using GameObjects;
using Services;
using UnityEngine;
namespace Managers
{
    public class BallSpawner
    {
        #region --- Members ---
        
        private readonly BallManager _ballManager;
        private readonly List<Ball> _spawnedBalls = new List<Ball>();
        private BallData _nextBallData;
        private event System.Action<BallData> OnNextBallDataChanged;
        
        #endregion
        
        
        #region --- Constants ---
        
        private const string BALL_TAG = "Ball";
        
        #endregion
        
        
        #region --- Constructor ---
        
        public BallSpawner(BallManager ballManager)
        {
            _ballManager = ballManager;
        }
        
        #endregion
        
        
        #region --- Public Methods ---
    
        public void SpawnBall()
        {
            var ballData = CheckIfNextBallDataExists() ? _nextBallData : GetRandomBallData();
            
            CreateBallGameObject(ballData);
        }
        
        public Ball GetActiveBall() 
        {
            return _spawnedBalls.FirstOrDefault(b => !b.Released);
        }
        
        public void SpawnBallWithScore(int score, Vector3 position1, Vector3 position2)
        {
            var ballData = GetBallDataByScore(score);
            LoggerService.Log("Spawning ball {0} with score: {1}", ballData.name, ballData.Score);

            var newBall = CreateBallGameObject(ballData);
            newBall.Release();
            SetBallPosition(newBall, position1, position2);
            newBall.gameObject.SetActive(true);
        }
        
        public void SubscribeToNextBallDataChanged(System.Action<BallData> onNextBallDataChanged)
        {
            OnNextBallDataChanged += onNextBallDataChanged;
        }
        
        public void UnsubscribeFromNextBallDataChanged(System.Action<BallData> onNextBallDataChanged)
        {
            OnNextBallDataChanged -= onNextBallDataChanged;
        }
        
        #endregion
        
        
        #region --- Private Methods ---

        private BallData GetRandomBallData()
        {
            return _ballManager.GetBallData();
        }
        
        private bool CheckIfNextBallDataExists()
        {
            if (_nextBallData != null)
            {
                return true;
            }

            SetAndInformNextBallData();
            return false;
        }

        private void SetAndInformNextBallData()
        {
            _nextBallData = GetRandomBallData();
            OnNextBallDataChanged?.Invoke(_nextBallData);
        }

        private Ball CreateBallGameObject(BallData ballData)
        {
            var newBall = new GameObject(BALL_TAG)
            {
                tag = BALL_TAG,
            };

            newBall.SetActive(false);
            newBall.AddComponent<SpriteRenderer>();
            newBall.AddComponent<CircleCollider2D>();
            newBall.AddComponent<Rigidbody2D>().isKinematic = true;
            var ball = newBall.AddComponent<Ball>();
            ball.Initialize(ballData);
            _spawnedBalls.Add(ball);
            
            LoggerService.Log("Spawning ball {0} with score: {1}", ballData.name, ballData.Score);
                                                    
            return ball;
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
        
        #endregion
    }
}
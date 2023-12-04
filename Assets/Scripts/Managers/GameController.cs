using Data;
using GameObjects;
using Services;
using UnityEngine;
namespace Managers
{
    [RequireComponent(typeof(CoroutineService))]
    public class GameController : MonoBehaviour
    {
        #region --- Members ---
        
        private BallManager _ballManager;
        private BallSpawner _ballSpawner;
        public static GameController Instance;
        
        #endregion
        
        
        #region --- Properties ---
    
        public ICoroutineService CoroutineService { get; private set; }
        public Ball ActiveBall
        {
            get
            {
                return _ballSpawner?.GetActiveBall();
            }
        }
        
        #endregion
        
        
        #region --- Public Methods ---
        
        public void SpawnBall()
        {
            //Add a short delay before spawning the ball
            CoroutineService.ExecuteAfterDelay(SpawnBallImpl, 0.5f);
        }
    
        public void SpawnBallWithScore(int score, Vector3 position1, Vector3 position2)
        {
            _ballSpawner.SpawnBallWithScore(score, position1, position2);
        }
        
        #endregion
        
        
        #region --- Private Methods ---

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                CoroutineService = GetComponent<CoroutineService>();
            }
            else
            {
                Destroy(gameObject);
            }
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
    
        #endregion
    }
}
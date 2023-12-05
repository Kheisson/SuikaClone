using Data;
using UI;
using UnityEngine;

namespace Managers
{
    public class UiManager : MonoBehaviour
    {
        #region --- Inspector ---
        
        [SerializeField] private NextBallView nextBallView;
        [SerializeField] private ScoreBoxView scoreView;
        
        #endregion
        
        
        #region --- Members ---
        
        private UserDataModel _userDataModel;
        private NextBallModel _nextBallModel;
        
        #endregion
        
        
        #region --- Public Methods ---
        
        public void UpdateScore(int addedScore)
        {
            var newScore = _userDataModel.CurrentScore + addedScore;
            
            UpdateCurrentScoreInternal(newScore);
            if (newScore > _userDataModel.BestScore)
            {
                UpdateBestScoreInternal(newScore);
            }
        }
        
        public void UpdateNextBall(BallData nextBallData)
        {
            UpdateNextBallInternal(nextBallData);
        }
        
        #endregion
        
        
        #region --- Private Methods ---

        private void Awake()
        {
            _userDataModel = new UserDataModel();
            _nextBallModel = new NextBallModel();
            
            UpdateCurrentScoreInternal(_userDataModel.CurrentScore);
            UpdateBestScoreInternal(_userDataModel.BestScore);
        }
        
        private void UpdateCurrentScoreInternal(int newScore)
        {
            _userDataModel.UpdateCurrentScore(newScore);
            scoreView.UpdateCurrentScore(_userDataModel.CurrentScore);
        }

        private void UpdateBestScoreInternal(int newBestScore)
        {
            _userDataModel.UpdateBestScore(newBestScore);
            scoreView.UpdateBestScore(_userDataModel.BestScore);
        }

        private void UpdateNextBallInternal(BallData nextBallData)
        {
            _nextBallModel.SetNextBallData(nextBallData);
            nextBallView.UpdateNextBallSprite(_nextBallModel.GetNextBallData());
        }
        
        #endregion
    }
}
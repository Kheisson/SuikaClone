using System.Collections;
using Data;
using Services;
using TMPro;
using UI;
using Unity.Services.Authentication;
using UnityEngine;

namespace Managers
{
    public class UiManager : MonoBehaviour
    {
        #region --- Inspector ---
        
        [SerializeField] private NextBallView _nextBallView;
        [SerializeField] private ScoreBoxView _scoreView;
        [SerializeField] private TextMeshProUGUI _playerIdText;
        
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
            UpdateBestScoreInternal(newScore);
        }
        
        public void UpdateNextBall(BallData nextBallData)
        {
            UpdateNextBallInternal(nextBallData);
        }
        
        #endregion
        
        
        #region --- Private Methods ---

        private async void Awake()
        {
            _userDataModel = await UserDataModel.CreateAsync(AuthenticationService.Instance.IsSignedIn ? new CloudStorageService() : new LocalStorageService());
            _nextBallModel = new NextBallModel();
        }
        
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => UserDataModel.DidFinishSetup);
            
            UpdateCurrentScoreInternal(_userDataModel.CurrentScore);
            UpdateBestScoreInternal(_userDataModel.BestScore);
            UpdatePlayerIdInternal();
        }
        
        private void UpdateCurrentScoreInternal(int newScore)
        {
            _userDataModel.UpdateCurrentScore(newScore);
            _scoreView.UpdateCurrentScore(_userDataModel.CurrentScore);
        }

        private void UpdateBestScoreInternal(int newBestScore)
        {
            if (!_userDataModel.UpdateBestScore(newBestScore))
            {
                return;
            }
            
            _scoreView.UpdateBestScore(_userDataModel.BestScore);
        }

        private void UpdateNextBallInternal(BallData nextBallData)
        {
            _nextBallModel.SetNextBallData(nextBallData);
            _nextBallView.UpdateNextBallSprite(_nextBallModel.GetNextBallData());
        }
        
        private void UpdatePlayerIdInternal()
        {
            if (AuthenticationService.Instance.IsSignedIn)
            {
                _playerIdText.text = $"Player ID: {AuthenticationService.Instance.PlayerId}";
                return;
            }

            _playerIdText.text = "";
        }
        
        #endregion
    }
}
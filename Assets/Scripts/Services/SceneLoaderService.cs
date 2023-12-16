using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoaderService
    {
        private const string GAME_SCENE_NAME = "GameScene";
        private readonly UserAuthenticationService _userAuthenticationService;

        public SceneLoaderService(UserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
            SubscribeToAuthenticationServiceEvents();
        }
        
        private void SubscribeToAuthenticationServiceEvents()
        {
            _userAuthenticationService.OnSignedIn -= LoadGameScene;
            _userAuthenticationService.OnSignedIn += LoadGameScene;
            _userAuthenticationService.OnSignedOut -= OnSignedOut;
            _userAuthenticationService.OnSignedOut += OnSignedOut;
            _userAuthenticationService.OnExpired -= OnPlayerSessionExpired;
            _userAuthenticationService.OnExpired += OnPlayerSessionExpired;
        }

        private void LoadGameScene(string playerId)
        {
            LoggerService.Log($"Player signed in with id: {playerId}");
            SceneManager.LoadScene(GAME_SCENE_NAME);
        }

        private void OnSignedOut()
        {
            LoggerService.Log("Player signed out.");
        }
        
        private void OnPlayerSessionExpired()
        {
            LoggerService.Log("Player session expired.");
        }
    }
}
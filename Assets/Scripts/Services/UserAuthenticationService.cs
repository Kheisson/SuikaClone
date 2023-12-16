using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace Services
{
    public class UserAuthenticationService : MonoBehaviour
    {
        #region --- Events ---
        
        public delegate void SignedInHandler(string playerId);
        public delegate void SignInFailedHandler(string errorMessage);
        public delegate void SignedOutHandler();
        public delegate void ExpiredHandler();
        
        public static event SignedInHandler OnSignedIn;     
        public static event SignInFailedHandler OnSignInFailed;
        public static event SignedOutHandler OnSignedOut;
        public static event ExpiredHandler OnExpired;
        
        #endregion
        
        
        #region --- MonoBehaviour Methods ---
        
        private async void Awake()
        {
            try
            {
                await UnityServices.InitializeAsync();
                SetupEvents();
            }
            catch (Exception e)
            {
                LoggerService.LogError(e.Message);
            }
        }
        
        #endregion
        
        
        #region --- Private Methods ---
        
        private void SetupEvents()
        {
            AuthenticationService.Instance.SignedIn += RaiseOnSignedIn;
            AuthenticationService.Instance.SignInFailed += RaiseOnSignInFailed;
            AuthenticationService.Instance.SignedOut += RaiseOnSignedOut;
            AuthenticationService.Instance.Expired += RaiseOnExpired;
        }

        private async Task SignInAnonymouslyAsync()
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                LoggerService.Log("Sign in anonymously succeeded!");
                LoggerService.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
            }
            catch (AuthenticationException ex)
            {
                LoggerService.LogError("An authentication error occurred.", ex.Message);
            }
            catch (RequestFailedException ex)
            {
                LoggerService.LogError("A request error occurred.", ex.Message);
            }
        }
        
        private void RaiseOnSignedIn()
        {
            var playerId = AuthenticationService.Instance.PlayerId;
            LoggerService.Log($"PlayerID: {playerId}");

            OnSignedIn?.Invoke(playerId);
        }
        
        private void RaiseOnSignInFailed(RequestFailedException errorMessage)
        {
            LoggerService.LogError(errorMessage.Message);
            OnSignInFailed?.Invoke(errorMessage.Message);
        }
        
        private void RaiseOnSignedOut()
        {
            LoggerService.Log("Player signed out.");
            OnSignedOut?.Invoke();
        }
        
        private void RaiseOnExpired()
        {
            LoggerService.Log("Player session could not be refreshed and expired.");
            OnExpired?.Invoke();
        }
        
        #endregion
        
        
        #region --- Public Methods ---

        /// <summary>
        /// This method is called when the login button is pressed.
        /// </summary>
        public async void OnLoginButtonPressed()
        {
            await SignInAnonymouslyAsync();
        }
        
        #endregion
    }
}
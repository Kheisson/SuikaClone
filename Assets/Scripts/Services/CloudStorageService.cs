using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;

namespace Services
{
    public class CloudStorageService : IStorageService
    {
        #region --- Constants ---
        
        private const string BEST_SCORE_KEY = "bestScore";
        
        #endregion
        
        
        #region --- Fields ----
        
        private readonly HashSet<string> _keys = new HashSet<string> {BEST_SCORE_KEY};
        
        #endregion
        
        
        #region --- Public Methods ---
        
        public async Task<int> GetBestScore()
        {
            try
            {
                var playerData = await CloudSaveService.Instance.Data.Player.LoadAsync(_keys);

                if (playerData.TryGetValue(BEST_SCORE_KEY, out var bestScore))
                {
                    LoggerService.Log($"Best score loaded successfully! {bestScore.Value.GetAsString()}");
                    return bestScore.Value.GetAs<int>();
                }

                return 0;
            }  
            catch (System.Exception e)
            {
                LoggerService.LogError(e.Message);
                return 0;
            }
        }

        public async void SaveBestScore(int bestScore)
        {
            try
            {
                var playerData = new Dictionary<string, object>
                    { {BEST_SCORE_KEY, bestScore} };

                await CloudSaveService.Instance.Data.Player.SaveAsync(playerData);
                
                LoggerService.Log($"Best score saved successfully! {bestScore}");
            } 
            catch (System.Exception e)
            {
                LoggerService.LogError(e.Message);
            }
        }
        
        #endregion
    }
}
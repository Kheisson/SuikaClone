using System.Threading.Tasks;
using UnityEngine;

namespace Services
{
    public class LocalStorageService : IStorageService
    {
        #region --- Constants ---
        
        private const string BEST_SCORE_KEY = "BestScore";

        #endregion
        
        
        #region --- Public Methods ---
        
        public Task<int> GetBestScore()
        {
            return Task.FromResult(PlayerPrefs.GetInt(BEST_SCORE_KEY, 0));
        }

        public void SaveBestScore(int bestScore)
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, bestScore);
            PlayerPrefs.Save();
        }
        
        #endregion
    }
}
using System;
using System.Threading.Tasks;
using Services;

namespace Data
{
    public class UserDataModel
    {
        #region --- Members ---
        
        private int _currentScore;
        private int _bestScore;
        private readonly IStorageService _storageService;
        
        #endregion

        
        #region --- Properties ---
        
        public int CurrentScore
        {
            get
            {
                return _currentScore;
            }
        }
        public int BestScore
        {
            get
            {
                return _bestScore;
            }
        }
        
        public static bool DidFinishSetup
        {
            get;
            private set;
        }
        
        #endregion
        
        
        #region --- Constructor ---

        private UserDataModel(IStorageService storageService)
        {
            _storageService = storageService;
        }
        
        #endregion
        
        #region --- Public Methods ---
        
        public static async Task<UserDataModel> CreateAsync(IStorageService storageService)
        {
            var userDataModel = new UserDataModel(storageService);
            userDataModel._bestScore = await userDataModel._storageService.GetBestScore();
            DidFinishSetup = true;
            
            return userDataModel;
        }
        
        public void UpdateCurrentScore(int newScore)
        {
            _currentScore = newScore;
        }

        public bool UpdateBestScore(int newBestScore)
        {
            if (newBestScore < _bestScore)
            {
                return false;
            }
            
            _bestScore = newBestScore;
            _storageService.SaveBestScore(newBestScore);
            return true;
        }
        
        #endregion
    }
}
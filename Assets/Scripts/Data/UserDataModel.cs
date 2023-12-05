namespace Data
{
    public class UserDataModel
    {
        #region --- Members ---
        
        private int _currentScore;
        private int _bestScore;
        
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
        
        #endregion

        
        #region --- Constructor ---
        
        public UserDataModel()
        {
            _currentScore = 0;
            _bestScore = 0;
        }
        
        #endregion

        
        #region --- Public Methods ---
        
        public void UpdateCurrentScore(int newScore)
        {
            _currentScore = newScore;
            // You might want to check if the current score is higher than the best score here and update accordingly.
        }

        public void UpdateBestScore(int newBestScore)
        {
            _bestScore = newBestScore;
        }
        
        #endregion
    }
}
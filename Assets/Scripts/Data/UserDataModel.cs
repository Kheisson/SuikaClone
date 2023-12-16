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
        
        
        #region --- Public Methods ---
        
        public void UpdateCurrentScore(int newScore)
        {
            _currentScore = newScore;
        }

        public void UpdateBestScore(int newBestScore)
        {
            _bestScore = newBestScore;
        }
        
        #endregion
    }
}
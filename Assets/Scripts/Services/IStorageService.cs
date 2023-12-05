namespace Services
{
    public interface IStorageService
    {
        #region --- Methods ---
        
        int GetBestScore();
        void SaveBestScore(int bestScore);
        
        #endregion
    }
}
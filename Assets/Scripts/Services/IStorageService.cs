using System.Threading.Tasks;

namespace Services
{
    public interface IStorageService
    {
        #region --- Methods ---
        
        Task<int> GetBestScore();
        void SaveBestScore(int bestScore);
        
        #endregion
    }
}
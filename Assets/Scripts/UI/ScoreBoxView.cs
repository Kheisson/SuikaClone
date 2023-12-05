using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreBoxView : MonoBehaviour
    {
        #region --- Inspector ---
        
        [SerializeField] private TextMeshProUGUI currentScoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;

        #endregion
        
        
        #region --- Public Methods ---
        
        public void UpdateCurrentScore(int newScore)
        {
            currentScoreText.text = $"{newScore}";
        }

        public void UpdateBestScore(int newBestScore)
        {
            bestScoreText.text = $"{newBestScore}";
        }
        
        #endregion
    }
}
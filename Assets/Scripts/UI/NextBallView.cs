using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NextBallView : MonoBehaviour
    {
        #region --- Inspector ---
        
        [SerializeField] private Image nextBallSprite;

        #endregion
        
        
        #region --- Public Methods ---
        
        public void UpdateNextBallSprite(BallData nextBallData)
        {
            nextBallSprite.sprite = nextBallData.Sprite;
        }
        
        #endregion
    }
}
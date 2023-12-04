using System;
using UnityEngine;
namespace Data
{
    [CreateAssetMenu(fileName = "New BallData", menuName = "Ball Data", order = 51)]
    public class BallData : ScriptableObject, IComparable<BallData>
    {
        #region --- Inspcector ---
        
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _score;
        [SerializeField] private float _size;
        
        #endregion
    
        
        #region --- Properties ---
        
        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
        public int Score
        {
            get
            {
                return _score;
            }
        }
        public float Size
        {
            get
            {
                return _size;
            }
        }
        
        #endregion
        
        
        #region --- Public Methods ---
    
        public int CompareTo(BallData other)
        {
            return _score.CompareTo(other._score);
        }
        
        #endregion
    }
}
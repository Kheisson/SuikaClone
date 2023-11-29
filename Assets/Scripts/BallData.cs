using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New BallData", menuName = "Ball Data", order = 51)]
public class BallData : ScriptableObject, IComparable<BallData>
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _score;
    [SerializeField] private float _size;
    
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
    
    public int CompareTo(BallData other)
    {
        return _score.CompareTo(other._score);
    }
}
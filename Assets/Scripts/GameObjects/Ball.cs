using Data;
using Managers;
using Services;
using UnityEngine;
namespace GameObjects
{
    public class Ball : MonoBehaviour
    {
        #region --- Members ---
        
        private BallData _ballData;
        
        #endregion
        
        
        #region --- Properties ---
        
        public bool Released { get; private set; } = false;
        
        #endregion
        
        
        #region --- Public Methods ---

        public void Initialize(BallData ballData)
        {
            _ballData = ballData;
            SetSprite(ballData.Sprite);
            SetSize(ballData.Size);
        }
    
        public void Release()
        {
            Released = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
        
        #endregion
        
        
        #region --- Private Methods ---
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(nameof(Ball)))
            {
                return;
            }

            var otherBall = collision.gameObject.GetComponent<Ball>();
            MergeWithCollision(otherBall);
        }

        private void SetSprite(Sprite sprite)
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }

        private void SetSize(float size)
        {
            var modSize = size / 10;
            transform.localScale = new Vector3(modSize, modSize, 1);
        }
    
        private void MergeWithCollision(Ball otherBall)
        {
            if (otherBall == null || !Released || !otherBall.Released || !CompareBallData(otherBall))
            {
                return;
            }
    
            if (gameObject.GetInstanceID() < otherBall.gameObject.GetInstanceID())
            {
                return;
            }

            var mergedScore = _ballData.Score + otherBall._ballData.Score;
            GameController.Instance.SpawnBallWithScore(mergedScore, transform.position, otherBall.transform.position);
            LoggerService.Log("Merging balls {0} and {1}", _ballData.name, otherBall._ballData.name);
            Destroy(gameObject);
            Destroy(otherBall.gameObject);
        }

        private bool CompareBallData(Ball otherBall)
        {
            return _ballData.CompareTo(otherBall._ballData) == 0;
        }
        
        #endregion
    }
}
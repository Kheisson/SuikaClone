using UnityEngine;
namespace Managers
{
    public class InputHandler : MonoBehaviour
    {
        #region --- Inspector ---
        
        [SerializeField] private Transform _container;
        
        #endregion
        
        
        #region --- Members ---
        
        private Camera _mainCamera;
    
        #endregion
        
        
        #region --- Private Methods ---
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }
    
        private void Update()
        {
            KeepTrackOfBall();
            HandleMouseInput();
        }

        private void HandleMouseInput()
        {
            if (Input.GetMouseButtonUp(0))
            {
                ReleaseBall();
            }
        }
    
        private void KeepTrackOfBall()
        {
            var ball = GameController.Instance.ActiveBall;

            if (ball == null)
            {
                return;
            }

            var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    
            var position = _container.position;
            var localScale = _container.localScale;
            var leftLimit = position.x - localScale.x / 2;
            var rightLimit = position.x + localScale.x / 2;
            var restrictedXPosition = Mathf.Clamp(mousePosition.x, leftLimit, rightLimit);

            var yPos = position.y + localScale.y / 2;

            var ballPosition = new Vector3(restrictedXPosition, yPos, 0);
            ball.transform.position = ballPosition;
            ball.gameObject.SetActive(true);
        }
    
        private void ReleaseBall()
        {
            var ball = GameController.Instance.ActiveBall;

            if (ball == null)
            {
                return;
            }

            ball.Release();
            GameController.Instance.SpawnBall();
        }
        
        #endregion
    }
}                        

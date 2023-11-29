using System.Linq;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Transform _container;
    private Camera _mainCamera;
    
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
        var ball = FindObjectsOfType<Ball>().FirstOrDefault(b => !b.Released);

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
    }
    
    private void ReleaseBall()
    {
        var ball = FindObjectsOfType<Ball>().FirstOrDefault(b => !b.Released);

        if (ball == null)
        {
            return;
        }

        ball.Release();
        GameController.Instance.SpawnBall();
    }
}                        

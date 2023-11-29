using UnityEngine;

public class Ball : MonoBehaviour
{
    private Camera _mainCamera;
    private int _score;
    private BallData _ballData;
    public bool Released { get; private set; } = false;

    public void Initialize(BallData ballData)
    {
        _mainCamera = Camera.main;
        _ballData = ballData;
        SetSprite(ballData.Sprite);
        SetScore(ballData.Score);
        SetSize(ballData.Size);
    }
    
    public void Release()
    {
        Released = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
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
    
    private void SetScore(int score)
    {
        _score = score;
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
        Destroy(gameObject);
        Destroy(otherBall.gameObject);
    }

    private bool CompareBallData(Ball otherBall)
    {
        return _ballData.CompareTo(otherBall._ballData) == 0;
    }
}
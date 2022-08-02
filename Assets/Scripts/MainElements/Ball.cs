using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _platformTransform;
    [SerializeField] private Vector2 _launchForce;
    [SerializeField] private int randomFactorX;
    [SerializeField] private int randomFactorY;

    private Rigidbody2D _rigidbody;

    private bool _isLaunched = false;
    private Vector2 _offset;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _offset = new Vector3
        (_platformTransform.position.x - transform.position.x, 
            _platformTransform.position.y - transform.position.y, 
            transform.position.z);
    }

    private void Update()
    {
        #if UNITY_STANDALONE
        if (!_isLaunched && InputManager.instance.CheckMouseButtonDown())
        {
            LaunchBall();
        }
        #elif UNITY_ANDROID
        if (!_isLaunched && InputManager.instance.CheckTouchCount())
        {
            LaunchBall();
        }
        #endif
        else if (!_isLaunched)
        {
           ChangePosition();
        }
    }

    private void ChangePosition()
    {
        transform.position = new Vector3
        (_platformTransform.position.x + _offset.x, 
            _platformTransform.position.y - _offset.y, 
            transform.position.z);
    }

    private void LaunchBall()
    {
        _rigidbody.velocity = _launchForce;
        _isLaunched = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isLaunched)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                Vector2 velocityTweak = new Vector2
                    (Random.Range(0, randomFactorX), 
                        Random.Range(0, randomFactorY));
                _rigidbody.velocity += velocityTweak;
            }
        }
    }
}
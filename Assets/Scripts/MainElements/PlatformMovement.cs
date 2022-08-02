using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    
    private Rigidbody2D _rigidbody;
    
    private float _destination;
    private float _startPosition;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position.x;
        _destination = transform.position.x;
    }
    
    private void Update()
    {
    #if UNITY_STANDALONE
        _destination = InputManager.instance.ChangePlatformPositionByMouse();
    #elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            _destination = InputManager.instance.ChangePlatformPositionByTouch();
        }
    #endif
    }
    
    private void FixedUpdate()
    {
        if (_startPosition > _destination)
        {
            if (transform.position.x < _destination)
            {
                DestinationIsReached();
            }
            else
            {
                Move(-_speed);
            }
        }
        else if(_startPosition<_destination)
        {
            if (transform.position.x > _destination)
            {
                DestinationIsReached();
            }
            else
            {
                Move(_speed);
            }
        }
    }
    
    private void DestinationIsReached()
    {
        _rigidbody.velocity = Vector2.zero;
        _startPosition = _destination;
    }

    private void Move(int speed)
    {
        _rigidbody.AddForce(new Vector2(speed,0f));
    }
}

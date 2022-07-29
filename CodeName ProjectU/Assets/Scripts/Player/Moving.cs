using UnityEngine;

[RequireComponent(typeof(WayDirectrion))] 
public class Moving : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _boost;
    [SerializeField] private SpriteRenderer _sprite;

    private float _correctSpeed;
    private WayDirectrion _way;
    private SpriteRotator _spriteRotator;
    private Direction _direction = Direction.Right;

    private void Awake()
    {
        _way = GetComponent<WayDirectrion>();
        _spriteRotator = GetComponent<SpriteRotator>();
    }

    private void FixedUpdate()
    {
        Walk();
    }
    private void Walk()
    {
        float move = Input.GetAxis("Horizontal");
        if (move == 0) 
        {
            _correctSpeed = 0;  
            return; 
        }
        _direction = move > 0 ? Direction.Right : Direction.Left;
        _spriteRotator.RotateBody(_direction);
        Vector2 direction = _way.GetDirection(_direction);
        if (Input.GetAxis("Sprint") > 0 && _correctSpeed <= _maxSpeed)
        {
            _correctSpeed += _boost;
            if (_correctSpeed > _maxSpeed)
            {
                _correctSpeed = _maxSpeed;
            }
        }
        else 
        { 
            _correctSpeed = _speed; 
        }
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.fixedDeltaTime * _correctSpeed;
    }
}
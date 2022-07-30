using UnityEngine;

[RequireComponent(typeof(WayDirectrion))] 
public class Moving : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _boost;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private AnimationCurve _jumpTraectory;

    private float _correctSpeed;
    private float _cantJumpSec;
    private float _correctJumpState;
    private float _hight;
    private bool _onGround;
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
        Jump();
        if (_cantJumpSec > 0)
        {
            _cantJumpSec -= Time.fixedDeltaTime;
        }
    }
    private void Update()
    {
        if (_correctJumpState > _jumpTraectory.keys[_jumpTraectory.keys.Length - 1].time)
        {
            _correctJumpState = 0;
        }
        if (_correctJumpState > 0)
        {
            _correctJumpState += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, _hight + _jumpTraectory.Evaluate(_correctJumpState));
        }
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
        if (_onGround == false)
        {
            transform.position += new Vector3(move, 0) * _correctSpeed * Time.fixedDeltaTime;
            return;
        }
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
        Debug.Log(move);
        _rigidbody2D.velocity = new Vector2(move, 0) * Time.fixedDeltaTime;
    }
    private void Jump()
    {
        if (Input.GetAxis("Vertical") > 0 && _onGround && _cantJumpSec <= 0)
        {
            _correctJumpState += 0.01f;
            _hight = transform.position.y;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onGround = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), Vector3.down, 0.1f).collider != null;
        _correctJumpState = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _onGround = false;
    }
}
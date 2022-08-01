using UnityEngine;
using UnityEngine.InputSystem;
 
[RequireComponent(typeof(WayDirectrion),typeof(SpriteRotator),typeof(Rigidbody2D))] 
public class Moving : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 4f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _boost = 0.04f;
    [SerializeField] private float _jumpCooldown = 0.1f;
    [SerializeField] private AnimationCurve _jumpTraectory;

    private InputAction _move;
    private InputAction _jump;
    private InputAction _sprint;
    private float _correctSpeed;
    private float _cantJumpSec;
    private float _correctJumpState;
    private bool _onGround;

    private PlayerInput _input;
    private WayDirectrion _way;
    private SpriteRotator _spriteRotator;
    private Rigidbody2D _rigidbody2D;
    private Direction _direction = Direction.Right;

    private void Awake()
    {
        _way = GetComponent<WayDirectrion>();
        _spriteRotator = GetComponent<SpriteRotator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _input = new PlayerInput();
        GetContol();
        _move.Enable();
        _jump.Enable();
        _sprint.Enable();
    }
    private void GetContol()
	{
        _move = _input.Player.Move;
        _jump = _input.Player.Jump;
        _sprint = _input.Player.Sprint;
    }
	private void OnDisable()
	{
        _move.Disable();
        _jump.Disable();
        _sprint.Disable();
    }
	private void Update()
    {
        Walk(_move.ReadValue<Vector2>().x, _sprint.ReadValue<float>());
        Jump(_jump.ReadValue<float>());
        JumpTimers();
    }
    private void Walk(float input, float sprint)
    {
        _direction = input > 0 ? Direction.Right : Direction.Left;
        Vector2 direction = _way.GetDirection(_direction);

        if (input == 0)
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            return;
        }
        _spriteRotator.RotateBody(_direction);
        if (_onGround == false)
        {
            Vector2 airTargetVelocity = new Vector2(input * _correctSpeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = airTargetVelocity;
            return;
        }
        CalculateSpeed(sprint);
        Vector2 targetVelocity = new Vector2(direction.x * Time.fixedDeltaTime * _correctSpeed, _rigidbody2D.velocity.y + direction.y * Time.fixedDeltaTime);
        _rigidbody2D.velocity = targetVelocity;
    }
    private void CalculateSpeed(float sprint)
	{
        if (sprint > 0 && _correctSpeed <= _maxSpeed)
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
    }
    private void Jump(float input)
    {
        if (_cantJumpSec <= 0 && input > 0)
        {
            _correctJumpState += 0.01f;
            _cantJumpSec = _jumpCooldown;
        }
    }
    private void JumpTimers()
	{
        if (_correctJumpState > _jumpTraectory.keys[_jumpTraectory.keys.Length - 1].time)
        {
            _correctJumpState = 0;
        }
        if (_correctJumpState > 0)
        {
            _correctJumpState += Time.deltaTime;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpTraectory.Evaluate(_correctJumpState));
        }
        if (_cantJumpSec > 0 && _onGround)
        {
            _cantJumpSec -= Time.deltaTime;
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
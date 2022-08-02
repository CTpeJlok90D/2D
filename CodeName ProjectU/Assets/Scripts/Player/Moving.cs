using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(WayDirectrion), typeof(SpriteRotator), typeof(Rigidbody2D))]
public class Moving : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 4f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpCooldown = 0.1f;
    [SerializeField] private AnimationCurve _jumpTraectory;

    private float _correctSpeed;
    private float _cantJumpSec;
    private bool _onGround;

    private PlayerInput _input;
    private InputAction _move;
    private InputAction _jump;
    private InputAction _sprint;
    private WayDirectrion _way;
    private SpriteRotator _spriteRotator;
    private Rigidbody2D _rigidbody2D;

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
    private void FixedUpdate()
    {
        Walk(_move.ReadValue<Vector2>().x, _sprint.ReadValue<float>());
        ReduceCooldowns();
    }
    private void Update()
    {
        Jump(_jump.ReadValue<float>());
    }
    private void Walk(float inputAxe, float inputSprint)
    {
        if (inputAxe == 0)
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            return;
        }
        _spriteRotator.RotateBody(inputAxe);
        _correctSpeed = CalculateSpeed(inputSprint);
        if (_onGround == false)
        {
            Vector2 airTargetVelocity = new Vector2(_correctSpeed * inputAxe * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = airTargetVelocity;
            return;
        }
        _rigidbody2D.velocity = CalculateVelocity(inputAxe, _correctSpeed * Time.fixedDeltaTime);
    }
    private Vector2 CalculateVelocity(float inputAxe, float speed)
    {
        Vector2 direction = _way.GetDirection(inputAxe);
        return new Vector2(direction.x * Mathf.Abs(speed), direction.y * Mathf.Abs(speed));
    }
    private float CalculateSpeed(float inputSprint)
    {
        float result = _correctSpeed;
        if (inputSprint > 0)
        {
            result = _maxSpeed;
        }
        else
        {
            result = _speed;
        }
        return result;
    }
    private void Jump(float input)
    {
        if (_cantJumpSec <= 0 && input > 0 && _onGround)
        {
            StartCoroutine("JumpTimers");
            _cantJumpSec = _jumpCooldown;
        }
    }
    private IEnumerator JumpTimers()
	{
        for(float state = 0; state < _jumpTraectory.keys[_jumpTraectory.keys.Length - 1].time; state += Time.deltaTime)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpTraectory.Evaluate(state));
            yield return null;
        }
    }
    private void ReduceCooldowns()
    {
        if(_onGround && _cantJumpSec > 0)
        {
            _cantJumpSec -= Time.fixedDeltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onGround = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), Vector3.down, 0.1f).collider != null;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _onGround = false;
    }
}
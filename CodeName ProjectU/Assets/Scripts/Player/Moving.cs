using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(WayDirectrion), typeof(Rigidbody2D))]
public class Moving : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 4f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpCooldown = 0.1f;
    [SerializeField] private AnimationCurve _jumpTraectory;
    [SerializeField] private Vector2 _onGroundOffcet;

    private float _correctSpeed;
    private float _cantJumpSec;
    private bool _onGround;
    private bool _sprinting;
    private float _jumpState;
    private int _walkDirection;

    private WayDirectrion _way;
    private Rigidbody2D _rigidbody2D;

    public void Move(InputAction.CallbackContext context)
    {
        _walkDirection = 0;
        if (context.performed || context.started)
        {
            _walkDirection = Mathf.RoundToInt(context.ReadValue<Vector2>().x);
        }
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        _sprinting = context.performed;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (_cantJumpSec <= 0 && context.started && _onGround)
        {
            StartCoroutine(nameof(JumpCorutine));
            _cantJumpSec = _jumpCooldown;
        }
    }
    private IEnumerator JumpCorutine()
	{
        for(float state = 0; state < _jumpTraectory.keys[_jumpTraectory.keys.Length - 1].time; state += Time.deltaTime)
        {
            _jumpState = _jumpTraectory.Evaluate(state);
            yield return null;
        }
        _jumpState = 0;
    }
    private void ApplyVelocity()
    {
        if (_walkDirection == 0)
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y + _jumpState);
            return;
        }
        _correctSpeed = CalculateSpeed();
        if (_onGround == false)
        {
            Vector2 airTargetVelocity = new Vector2(_correctSpeed * _walkDirection * Time.fixedDeltaTime, _rigidbody2D.velocity.y + _jumpState);
            _rigidbody2D.velocity = airTargetVelocity;
            return;
        }
        Vector2 direction = _way.GetDirection(_walkDirection);
        _rigidbody2D.velocity = new Vector2(direction.x * _correctSpeed * Time.fixedDeltaTime, direction.y * _correctSpeed * Time.fixedDeltaTime + _jumpState);
    }
    private float CalculateSpeed()
    {
        if (_sprinting)
        {
            return _maxSpeed;
        }
        return _speed;
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
        _onGround = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) + _onGroundOffcet, Vector2.down, 0.1f).collider != null;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _onGround = false;
    }
    private void Awake()
    {
        _way = GetComponent<WayDirectrion>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        ApplyVelocity();
        ReduceCooldowns();
    }
    private void OnDrawGizmos()
    {
        Vector2 vector = new Vector2(transform.position.x, transform.position.y);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(vector + _onGroundOffcet, vector + _onGroundOffcet + Vector2.down);
    }
}
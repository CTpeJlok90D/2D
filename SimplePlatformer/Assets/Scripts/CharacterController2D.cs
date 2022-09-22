using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    public float SpeedMultiplier = 1f;
    public float JumpForseMultiplier = 1f;

    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private Vector2 _groundRayCastOffcet;

    private float _moveDirection = 0f;
    private float _jumpForse = 0f;
    private Rigidbody2D _rigidbody2D;
    private float _cantJumpNextTime = 0f;
    private Coroutine _jumpCoroutine;
    private bool _jumping;
    private bool _onGround = true;
    private bool _canMove = true;

    public bool Moving => _canMove && _moveDirection != 0;
    public bool CanJump => _cantJumpNextTime == 0;
    public bool OnGround => _onGround;
    public bool Jumping => _jumping;
    public float MoveDirection => _moveDirection;

    public void SetControlActive(bool value)
    {
        _canMove = value;
    }

    public void Kick(Vector2 velocity)
    {
        _rigidbody2D.velocity = velocity;
    }

    protected void Move(float direction)
    {
        _moveDirection = direction;
    }

    protected void Jump()
    {
        if (CanJump == false)
        {
            return;
        }
        _jumpCoroutine = StartCoroutine(nameof(JumpCorrutine));
    }

    protected void StopJump()
    {
        if (Jumping)
        {
            StopCoroutine(_jumpCoroutine);
            _jumping = false;
            _jumpForse = 0;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        }
    }

    private IEnumerator JumpCorrutine()
    {
        _jumping = true;
        for (float i = 0; i < _jumpCurve.keys[_jumpCurve.keys.Length - 1].time; i += Time.fixedDeltaTime)
        {
            _jumpForse = _jumpCurve.Evaluate(i);
            _cantJumpNextTime = _jumpCooldown;
            yield return null;
        }
        _jumping = false;
        _jumpForse = 0;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            ApplyMoveVelocity();
        }
        
        if (OnGround && _cantJumpNextTime > 0)
        {
            _cantJumpNextTime = Mathf.Clamp(_cantJumpNextTime - Time.fixedDeltaTime, 0, Mathf.Infinity);
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        _onGround = true;   
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _onGround = false;
    }
    private void ApplyMoveVelocity()
    {
        _rigidbody2D.velocity = new Vector2(_speed * SpeedMultiplier * _moveDirection, _rigidbody2D.velocity.y);
        if (Jumping)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForse * JumpForseMultiplier);
        }
    }
}
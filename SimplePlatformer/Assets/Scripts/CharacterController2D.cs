using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour, IHaveDirection
{
    [HideInInspector] public float SpeedMultiplier = 1f;
    [HideInInspector] public float JumpForseMultiplier = 1f;
    [Header("Move")]
    [SerializeField] private float _speed;
    [Header("Jumping")]
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private GroundCheker _groundCheker;
    [Header("Crouch")]
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private Vector2 _crouchColliderSize;
    [SerializeField] private Vector2 _crouchColliderOffect;
    [SerializeField] private float _crouchingSpeed;
    private Rigidbody2D _rigidbody2D;
    private Coroutine _jumpCoroutine;
    private float _moveDirection = 0f;
    private float _jumpForse = 0f;
    private float _cantJumpNextTime = 0f;
    private bool _jumping;
    private bool _canMove = true;
    private bool _crouching = false;
    private int _lookDirection = 1;
    private UnityEvent _crashIntoSomething = new();
    private float _controlBlockNextSeconds = 0f;
    private Vector2 _startColliderSize;
    private Vector2 _startColliderOffect;

    public bool Moving => _canMove && _moveDirection != 0;
    public bool CanJump => _cantJumpNextTime == 0;
    public bool Jumping => _jumping;
    public float MoveDirection => _moveDirection;
    public bool CanMove => _canMove && _controlBlockNextSeconds == 0;
    public UnityEvent CrashIntoSomething => _crashIntoSomething;
    public int Direction => _lookDirection;
    public bool Crouching => _crouching;

    public void SetActiveControl(bool value)
    {
        _canMove = value;
    }

    public void Kick(Vector2 velocity)
    {
        _rigidbody2D.velocity = velocity;
    }

    public void EnableControl()
    {
        _canMove = true;
    }

    public void DisableControl()
    {
        _canMove = false;
    }
    
    public void BlockControlOn(float seconds)
    {
        _controlBlockNextSeconds = seconds;
    }

    protected void Move(float direction)
    {
        _moveDirection = direction;
        UpdateLookDirection();
    }

    protected void Jump()
    {
        if (CanJump == false)
        {
            return;
        }
        _jumpCoroutine = StartCoroutine(nameof(JumpCorrutine));
    }

    protected void StartCrouch()
    {
        if(_groundCheker.OnGround == false)
        {
            return;
        }
        _collider.size = _crouchColliderSize;
        _collider.offset = _crouchColliderOffect;
        _crouching = true;
    }

    protected void StopCrouch()
    {
        _collider.size = _startColliderSize;
        _collider.offset = _startColliderOffect;
        _crouching = false;
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
        for (float i = 0; i < _jumpCurve.keys[_jumpCurve.keys.Length - 1].time / 2; i += Time.fixedDeltaTime)
        {
            _jumpForse = _jumpCurve.Evaluate(i);
            _cantJumpNextTime = _jumpCooldown;
            yield return null;
        }
        _jumping = false;
        _jumpForse = 0;
    }

    private void ApplyMoveVelocity()
    {
        float currentSpeed = Crouching ? _crouchingSpeed : _speed;
        _rigidbody2D.velocity = new Vector2(currentSpeed * SpeedMultiplier * _moveDirection, _rigidbody2D.velocity.y);
        if (Jumping)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForse * JumpForseMultiplier);
        }
    }

    private void UpdateLookDirection()
    {
        if (MoveDirection == 0)
        {
            return;
        }
        _lookDirection = (int)MoveDirection;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startColliderSize = _collider.size;
        _startColliderOffect = _collider.offset;
    }

    private void Update()
    {
        if (CanMove)
        {
            ApplyMoveVelocity();
        }
        
        if (_groundCheker.OnGround && _cantJumpNextTime > 0)
        {
            _cantJumpNextTime = Mathf.Clamp(_cantJumpNextTime - Time.deltaTime, 0, Mathf.Infinity);
        }

        _controlBlockNextSeconds = Mathf.Clamp(_controlBlockNextSeconds - Time.deltaTime, 0, Mathf.Infinity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _crashIntoSomething.Invoke();
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D),typeof(MoveSpecifications))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private Vector2 _onGroundRayCastoffset;
    private Rigidbody2D _rigidbody2D;
    private MoveSpecifications _specifications;
    private float _jumpTime = 1f;
    private bool _isSprinting = false;
    private bool _canMove = true;
    private bool _onGround = false;
    private int _moveDirection;
    private float _correctMoveSpped = 0f;
    private float _correctMaxMoveSpeed = 0;
    private float _correctBoost = 0f;
    private float _correctJumpCooldown = 0f;

    protected bool OnGround => _onGround;

    public void Walk(int Direction)
    {
        _isSprinting = false;
        _moveDirection = Direction;
    }

    public void Run(int Direction)
    {
        _isSprinting = true;
        _moveDirection = Direction;
    }

    public void Stop()
    {
        _moveDirection = 0;
    }

    public void Jump()
    {
        StartCoroutine(nameof(JumpCorrutine));
    }

    private IEnumerator JumpCorrutine()
    {
        for (float i = 0; i < _jumpTime; i += Time.fixedDeltaTime)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _specifications.JumpForseCurve.Evaluate(i));
            yield return null;
        }
    }

    private void Move()
    {
        CalculateBoost();
        CalculateMaxSpeed();
        if (_moveDirection != 0)
        {
            _correctMoveSpped += _correctBoost * Time.fixedDeltaTime;
        }
        else
        {
            _correctMoveSpped = Mathf.MoveTowards(_correctMoveSpped, 0, _specifications.BrakingForce * Time.fixedDeltaTime);
        }
        _correctMoveSpped = Mathf.Clamp(_correctMoveSpped, -_correctMaxMoveSpeed, _correctMaxMoveSpeed);
        _rigidbody2D.velocity = new Vector2(_correctMoveSpped, _rigidbody2D.velocity.y);
    }

    private void CalculateBoost()
    {
        _correctBoost = (_isSprinting ? _specifications.SprintBoost : _specifications.WalkBoost) * _moveDirection;
    }

    private void CalculateMaxSpeed()
    {
        _correctMaxMoveSpeed = _isSprinting ? _specifications.MaxSprintSpeed : _specifications.MaxWalkSpeed;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _specifications = GetComponent<MoveSpecifications>();

        _jumpTime = _specifications.JumpForseCurve.keys[_specifications.JumpForseCurve.keys.Length - 1].time;
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
        }
        if (_correctJumpCooldown > 0 && _onGround)
        {
            _correctJumpCooldown = Mathf.Clamp(_correctJumpCooldown - Time.fixedDeltaTime, 0, Mathf.Infinity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(nameof(JumpCorrutine));

        _onGround = Physics2D.Raycast((Vector2)transform.position + _onGroundRayCastoffset, Vector2.down, 1f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _onGround = false;
    }
}
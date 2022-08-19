using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D),typeof(Specifications))]
public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Specifications _specifications;
    private float _correctMoveSpped = 0f;
    private float _correctMaxMoveSpeed = 0;
    private float _moveInput = 0f;
    private float _correctBoost = 0f;
    private float _jumpTime = 1f;
    private bool _isSprinting = false;
    private bool _canMove = true;

    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = (int)context.ReadValue<Vector2>().x;
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        _isSprinting = (context.canceled == false);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(nameof(JumpCorrutine));
        }
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
        if (_moveInput != 0)
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
        _correctBoost = (_isSprinting ? _specifications.SprintBoost : _specifications.WalkBoost) * _moveInput;
    }

    private void CalculateMaxSpeed()
    {
        _correctMaxMoveSpeed = _isSprinting ? _specifications.MaxSprintSpeed : _specifications.MaxWalkSpeed;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _specifications = GetComponent<Specifications>();

        _jumpTime = _specifications.JumpForseCurve.keys[_specifications.JumpForseCurve.keys.Length - 1].time;
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    public bool _nonTimeStun = false;

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
    private float _stunNextSeconds = 0f;
    private bool _onGround;

    public bool Moving => CanMove && _moveDirection != 0;
    public bool CanJump => _cantJumpNextTime == 0;
    public bool OnGround => _onGround;
    public bool Jumping => _jumping;
    public float MoveDirection => _moveDirection;
    private bool CanMove => _stunNextSeconds == 0 && _nonTimeStun == false;

    public void Stun(float time)
    {
        _rigidbody2D.velocity = Vector2.zero;
        _stunNextSeconds += time;
    }

    public void Kick(Vector2 velocity, float stunTime)
    {
        _stunNextSeconds += stunTime;
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
        StopCoroutine(_jumpCoroutine);
        _jumping = false;
        _jumpForse = 0;
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
        if (CanMove)
        {
            _rigidbody2D.velocity = new Vector2(_speed * _moveDirection, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity += new Vector2(0, _jumpForse);
        }
        
        if (OnGround && _cantJumpNextTime > 0)
        {
            _cantJumpNextTime = Mathf.Clamp(_cantJumpNextTime - Time.fixedDeltaTime, 0, Mathf.Infinity);
        }
        _stunNextSeconds = Mathf.Clamp(_stunNextSeconds - Time.fixedDeltaTime, 0, Mathf.Infinity);
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        _onGround = true;   
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _onGround = false;
    }
}
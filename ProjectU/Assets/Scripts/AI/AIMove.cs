using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WayDirectrion),typeof(SpriteRotator),typeof(Rigidbody2D)),RequireComponent(typeof(BotSpecifications))]
public class AIMove : MonoBehaviour
{
	[SerializeField] private float _minDistanceToTarget = 1f;
	[SerializeField] private AnimationCurve _jumpTraectory;
	[SerializeField] private UnityEvent _onPoint = new UnityEvent();

	private WayDirectrion _wayDirection;
	private SpriteRotator _spriteRotator;
	private Vector2 _targetPoint;
	private Specifications _specifications;
	private Rigidbody2D _rigidbody2D;
	private bool _onGround;
	private float _jumpState;

	public bool IsMoving => !OnPosition() && _targetPoint != Vector2.zero;
	public bool IsOnPosition => OnPosition();
	public UnityEvent OnPoint => _onPoint;

	public void SetTarget(Vector2 point)
	{
		_targetPoint = point;
	}
	public void GoTo(Vector2 point)
	{
		_targetPoint = point;
		GoTo();
	}
	public void GoTo(float xPoint)
    {
		_targetPoint = new Vector2(xPoint,0);
		GoTo();
	}
	public void GoTo()
	{
		if (_targetPoint != null)
		{
			_spriteRotator.InvertXItems(_targetPoint.x - transform.position.x);
			_spriteRotator.RotateItems(_targetPoint.x - transform.position.x);
		}
		if (_onGround == false)
		{
			return;
		}
		if (OnPosition() || IsPitInFront())
		{
			_targetPoint = Vector2.zero;
			_onPoint.Invoke();
			return;
		}
		//if (IsJumpingWallInFront())
		//{
		//	Jump();
		//}
		Vector2 moveDirection = _wayDirection.GetDirection(_spriteRotator.Direction);
		_rigidbody2D.velocity = new Vector2(_specifications.Speed * moveDirection.x, _rigidbody2D.velocity.y + _specifications.Speed * 0.3f * moveDirection.y);
	}
	private void Jump()
	{
		StartCoroutine(JumpState());
	}
	private IEnumerator JumpState()
	{
		for (float state = 0; state < _jumpTraectory.keys[_jumpTraectory.keys.Length - 1].time; state += Time.deltaTime)
		{
			_jumpState = _jumpTraectory.Evaluate(state);
			_rigidbody2D.velocity = new Vector2(_specifications.Speed, _jumpState);
			yield return null;
		}
	}
	private void Awake()
	{
		_wayDirection = GetComponent<WayDirectrion>();
		_spriteRotator = GetComponent<SpriteRotator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
		_specifications = GetComponent<Specifications>();
    }
    private bool IsJumpingWallInFront() => IsWallInFront() && Physics2D.Raycast(transform.position + new Vector3(0, transform.localScale.y / 2), new Vector2(_spriteRotator.Direction, 0), 0.5f) == false;
	private bool IsWallInFront() => Physics2D.RaycastAll(transform.position, new Vector2(_spriteRotator.Direction,0), 0.5f).Length > 1;
	private bool OnPosition() => (_targetPoint == null) ? true : (Mathf.Abs(_targetPoint.x - transform.position.x) < _minDistanceToTarget);
	private bool IsPitInFront() => Physics2D.Raycast(new Vector2(transform.position.x + 0.3f * _spriteRotator.Direction, transform.position.y), new Vector2(_spriteRotator.Direction * 0.1f, -0.5f),3).collider == null;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		_onGround = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), Vector3.down, 0.1f).collider != null;
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		_onGround = false;
	}
}

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WayDirectrion),typeof(SpriteRotator))]
public class AIMove : MonoBehaviour
{
	public readonly UnityEvent OnPoint = new UnityEvent();
	[SerializeField] private float _walkSpeed = 0.04f;

	private WayDirectrion _wayDirection;
	private SpriteRotator _spriteRotator;
	private Transform _targetPoint;

	public bool IsMoving => !OnPosition() && _targetPoint != null;
	public bool IsOnPosition => OnPosition();

	public void SetTarget(Transform point)
	{
		_targetPoint = point;
	}
	public void GoTo(Transform point)
	{
		_targetPoint = point;
		GoTo();
	}
	public void GoTo()
	{
		if (_targetPoint != null)
		{
			_spriteRotator.RotateAll(_targetPoint.position.x - transform.position.x > 0 ? Direction.Right : Direction.Left);
		}
		if (OnPosition() || IsPitInFront())
		{
			_targetPoint = null;
			OnPoint.Invoke();
			return;
		}
		Vector2 moveDirection = _wayDirection.GetDirection(_spriteRotator.Direction);
		transform.position = new Vector2(transform.position.x + _walkSpeed * moveDirection.x, transform.position.y + _walkSpeed * moveDirection.y);
	}
	private void Awake()
	{
		_wayDirection = GetComponent<WayDirectrion>();
		_spriteRotator = GetComponent<SpriteRotator>();
	}
	private bool OnPosition() => (_targetPoint == null) ? true : (Mathf.Round(_targetPoint.position.x) == Mathf.Round(transform.position.x));
	private bool IsPitInFront() => Physics2D.Raycast(new Vector2(transform.position.x + 0.3f * (_spriteRotator.Direction == Direction.Right ? 1 : -1), transform.position.y), new Vector2((_spriteRotator.Direction == Direction.Right ? 1 : -1) * 0.1f, -0.5f),3).collider == null;
}

using UnityEngine;

[RequireComponent(typeof(WayDirectrion))]
public class AIMove : MonoBehaviour
{
	[SerializeField] private Transform _targetPoint;
	[SerializeField] private float _walkSpeed = 0.04f;
	[SerializeField] private SpriteRenderer[] _escordItemsX;
	[SerializeField] private SpriteRenderer[] _escordItemsY;

	private WayDirectrion _wayDirection;
	private int _direction = 1;

	public bool IsMoving => !OnPosition() && _targetPoint != null;

	public void GoToTarget()
	{
		if (_targetPoint != null)
		{
			Rotate(_targetPoint.position.x - transform.position.x > 0 ? 1 : -1);
		}
		if (OnPosition() || IsPitInFront())
		{
			return;
		}
		Vector2 MoveDirection = _wayDirection.GetDirection(_direction);
		transform.position = new Vector2(transform.position.x + _walkSpeed * MoveDirection.x, transform.position.y + _walkSpeed * MoveDirection.y);
	}
	public void Rotate(int direction)
	{
		if (Mathf.Abs(direction) > 1)
		{
			throw new System.Exception($"Invalid value {direction}.\nIt must between -1 and 1");
		}
		_direction = direction;
		foreach (SpriteRenderer var in _escordItemsX)
		{
			var.flipX = _direction == -1;
		}
		foreach (SpriteRenderer var in _escordItemsY)
		{
			var.flipY = _direction == -1;
		}
	}
	private void Awake()
	{
		_wayDirection = GetComponent<WayDirectrion>();
	}
	private bool OnPosition() => (_targetPoint == null) ? true : (Mathf.Round(_targetPoint.position.x) == Mathf.Round(transform.position.x));
	private bool IsPitInFront() => Physics2D.Raycast(new Vector2(transform.position.x + 0.3f * _direction, transform.position.y), new Vector2(_direction * 0.1f, -0.5f),3).collider == null;
}

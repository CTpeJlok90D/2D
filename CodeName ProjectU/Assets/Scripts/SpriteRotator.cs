using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
	[SerializeField] private SpriteRenderer[] _bodyItemsX;
	[SerializeField] private SpriteRenderer _weapon;

	private Direction _direction = Direction.Right;

	public Direction Direction => _direction;
	public void RotateAll(Direction direction)
	{
		_direction = direction;
		RotateBody(direction);
		RotateWeapon(direction);
	}
	public void RotateBody(Direction direction)
	{
		_direction = direction;
		foreach (SpriteRenderer var in _bodyItemsX)
		{
			var.flipX = _direction == Direction.Left;
		}
	}
	private void RotateWeapon(Direction direction)
	{
		_weapon.flipX = _direction == Direction.Left;
	}
}

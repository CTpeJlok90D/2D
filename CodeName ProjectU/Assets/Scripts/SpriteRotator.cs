using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
	[Header("Escord items")]
	[SerializeField] private SpriteRenderer[] _bodyItemsX;
	[SerializeField] private SpriteRenderer[] _lookingItemsView;
	[SerializeField] private Transform[] _invertingItems;
	
	private Direction _direction = Direction.Right;

	public Direction Direction => _direction;
	public void RotateAll(Direction direction)
	{
		_direction = direction;
		RotateBody(direction);
		RotateItems(direction);
		InvertItems(direction);
	}
	public void RotateBody(Direction direction)
	{
		_direction = direction;
		foreach (SpriteRenderer var in _bodyItemsX)
		{
			var.flipX = _direction == Direction.Left;
		}
	}
	public void RotateItems(Direction direction)
	{
		foreach (SpriteRenderer item in _lookingItemsView)
		{
			item.flipY = direction == Direction.Left;
		}
	}
	public void RotateItems(Transform target)
	{
		foreach (SpriteRenderer item in _lookingItemsView)
		{
			item.transform.right = target.transform.position - item.transform.position;
		}
	}
	public void InvertItems(Direction direction)
	{
		foreach (Transform item in _invertingItems)
		{
			item.localScale = new Vector2(DirectionConvert.ToInt(direction), item.localScale.y);
		}
	}
}

using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
	[Header("Escord items")]
	[SerializeField] private SpriteRenderer[] _bodyItemsX;
	[SerializeField] private SpriteRenderer[] _lookingItemsView;
	[SerializeField] private Transform[] _invertingItems;
	
	private int _direction = 1;

	public int Direction => _direction;
	public void RotateAll(int direction)
	{
		_direction = direction;
		RotateBody(direction);
		RotateItems(direction);
		InvertItems(direction);
	}
	public void RotateAll(float direction)
    {
		RotateAll(direction > 0 ? 1 : -1);
    }
	public void RotateBody(int direction)
	{
		_direction = direction;
		foreach (SpriteRenderer var in _bodyItemsX)
		{
			var.flipX = _direction == -1;
		}
	}
	public void RotateBody(float direction)
    {
		RotateBody(direction > 0 ? 1 : -1);
    }
	public void RotateItems(int direction)
	{
		foreach (SpriteRenderer item in _lookingItemsView)
		{
			item.flipY = direction == -1;
		}
	}
	public void RotateItems(Transform target)
	{
		foreach (SpriteRenderer item in _lookingItemsView)
		{
			item.transform.right = target.transform.position - item.transform.position;
		}
	}
	public void InvertItems(int direction)
	{
		foreach (Transform item in _invertingItems)
		{
			item.localScale = new Vector2(direction, item.localScale.y);
		}
	}
}

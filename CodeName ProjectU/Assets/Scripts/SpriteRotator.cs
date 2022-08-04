using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
	[Header("Escord items")]
	[SerializeField] private SpriteRenderer[] _bodyItemsX;
	[SerializeField] private SpriteRenderer[] _bodyItemsY;
	[SerializeField] private Transform[] _lookingItemsView;
	[SerializeField] private Transform[] _invertingItemsX;
	[SerializeField] private Transform[] _invertingItemsY;
	
	private int _direction = 1;

	public int Direction => _direction;
	public void RotateAll(int direction)
	{
		_direction = direction;
		RotateBody(direction);
		InvertItems(direction);
		RotateItems(direction);
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
		foreach (SpriteRenderer var in _bodyItemsY)
		{
			var.flipY = _direction == -1;
		}
	}
	public void RotateItems(Vector3 targetPostion, float accusity = 1f)
	{
		foreach (Transform item in _lookingItemsView)
		{
			item.right = Vector2.MoveTowards(item.transform.right, targetPostion - item.transform.position, accusity);
		}
	}
	public void RotateItems(int direction)
	{
		foreach (Transform item in _lookingItemsView)
		{
			item.right = transform.right * direction;
		}
	}
	public void InvertItems(int direction)
	{
		InvertXItems(direction);
		InvertYItems(direction);
	}
	public void InvertXItems(int direction)
    {
		foreach (Transform item in _invertingItemsX)
		{
			item.localScale = new Vector2(direction, item.localScale.y);
		}
	}
	public void InvertYItems(int direction)
    {
		foreach (Transform item in _invertingItemsY)
		{
			item.localScale = new Vector2(item.localScale.x, direction);
		}
	}
	public void InvertXItems(float direction)
	{
		InvertXItems(direction > 0 ? 1 : -1);
	}
	public void InvertYItems(float direction)
	{
		InvertYItems(direction > 0 ? 1 : -1);
	}
	public void InvertItems(float direction)
	{
		InvertItems(direction > 0 ? 1 : -1);
	}
	public void RotateBody(float direction)
	{
		RotateBody(direction > 0 ? 1 : -1);
	}
	public void RotateItems(float direction)
    {
		RotateItems(direction > 0 ? 1 : -1);
	}
}

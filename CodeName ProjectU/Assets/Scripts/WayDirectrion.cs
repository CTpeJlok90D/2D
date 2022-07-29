using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WayDirectrion : MonoBehaviour
{
	[SerializeField] private bool _showWays;

	private Vector2 _normal;
	public Vector2 GetDirection(Direction lookDirectionX)
	{
		int multiply = lookDirectionX == Direction.Left ? -1 : 1;
		return new Vector2(_normal.y * multiply, -_normal.x * multiply);
	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		UpdateDirection(collision);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		UpdateDirection(collision);
	}
	public void UpdateDirection(Collision2D ground)
	{
		_normal = ground.contacts[0].normal;
	}
	private void OnDrawGizmos()
	{
		if (_showWays)
		{
			Vector2 way1 = GetDirection(Direction.Right);
			Vector2 way2 = GetDirection(Direction.Left);
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, new Vector2(way1.x * 2 + transform.position.x, way1.y * 2 + transform.position.y));
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, new Vector2(way2.x * 2 + transform.position.x, way2.y * 2 + transform.position.y));
		}
	}
}

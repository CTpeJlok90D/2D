using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class InstantietePower : MonoBehaviour
{
	[SerializeField] private Vector2 _startSpeed;

	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.velocity += _startSpeed.x * (Vector2)transform.right;
		_rigidbody.velocity += _startSpeed.y * (Vector2)transform.up;

	}
}

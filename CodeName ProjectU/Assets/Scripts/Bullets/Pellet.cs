using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class Pellet : Bullet
{
	[SerializeField] private float _startSpeed;
	[SerializeField] private int _damage;

	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.AddForce(transform.right * _startSpeed);

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}
}

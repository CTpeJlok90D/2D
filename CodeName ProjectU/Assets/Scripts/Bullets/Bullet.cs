using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float _lifeTime;

	private float _age;

	private void FixedUpdate()
	{
		_age += Time.fixedDeltaTime;
		if (_age >= _lifeTime)
		{
			Destroy(this.gameObject);
		}
	}
}

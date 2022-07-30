using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRotator))]
public class Senseorgans : MonoBehaviour
{
	[Header("Vision settings")]
	[SerializeField] private float _visionDistance = 10f;
	[SerializeField] private Transform[] _eyes;
	[SerializeField] private UnityEvent _seePlayer = new UnityEvent();

	private SpriteRotator _spriteRotator;

	public List<RaycastHit2D> Eye()
	{
		List<RaycastHit2D> result = new List<RaycastHit2D>();
		foreach (Transform eye in _eyes)
		{
			result.Add(Physics2D.Raycast(new Vector2(eye.position.x, eye.position.y), DirectionConvert.ToInt(_spriteRotator.Direction) * eye.right, _visionDistance));
		}
		return result;
	}

	private void Awake()
	{
		_spriteRotator = GetComponent<SpriteRotator>();
	}
	private void FixedUpdate()
	{
		foreach (RaycastHit2D visibleObject in Eye())
		{
			if (visibleObject.collider != null && visibleObject.collider.gameObject.TryGetComponent(out Player player))
			{
				_seePlayer.Invoke();
			}
		}
	}
}

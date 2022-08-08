using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRotator),typeof(BotSpecifications))]
public class AIShoot : MonoBehaviour
{
	[SerializeField] private Weapon _weapon;
	[SerializeField] private Transform _target;
	[SerializeField] private UnityEvent _shot;
	[SerializeField] private UnityEvent _objectGoFar;

	private SpriteRotator _spriteRotator;
	private BotSpecifications _specifications;
	private float _correctRecoil = 0f;
	private float _aimingTime = 0f;

	public void SetTarget(Transform target)
	{
		_target = target;
	}
	public void Shoot(Transform target)
	{
		_target = target;
		Shoot();
	}
	public void Shoot()
	{
		bool isTarget = false;
		foreach (RaycastHit2D hit in _weapon.OnGunPoint)
        {
			if (hit.collider.gameObject == _target.gameObject)
            {
				isTarget = true;
				break;
            }
        }
		Aim();
		if (isTarget == false)
		{
			_aimingTime += _specifications.AimTime;
		}
		if (isTarget && _aimingTime <= 0 && _weapon.CanShoot)
		{
			_weapon.Shoot();
			_shot.Invoke();
			_correctRecoil += _weapon.Recoil * (Vector2.Distance(transform.position, _target.position) * _specifications.AimRecoilMultiply);
		}
	}
	private void Aim()
	{
		_spriteRotator.InvertItems(_target.position.x - transform.position.x);
		_spriteRotator.RotateItems(_target.position + new Vector3(0, _correctRecoil), _weapon.Accusity * _specifications.AimSkill);
	}
	private void Awake()
	{
		_spriteRotator = GetComponent<SpriteRotator>();
		_specifications = GetComponent<BotSpecifications>();
	}
    private void FixedUpdate()
	{
		_correctRecoil = Mathf.Clamp(_correctRecoil - Time.fixedDeltaTime, 0, Mathf.Infinity);
		_aimingTime = Mathf.Clamp(_aimingTime - Time.fixedDeltaTime, 0, _specifications.AimTime);

		if (_target != null && Mathf.Abs(Vector2.Distance(transform.position, _target.position)) > _weapon.ShootDistance)
		{
			_objectGoFar.Invoke();
		}
	}
}

using UnityEngine;

[RequireComponent(typeof(AudioSource),typeof(SpriteRotator))]
public class AIShoot : MonoBehaviour
{
	[Header("Shooting")]
	[SerializeField] private AudioClip _shootSound;
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _weapon;
	[SerializeField] private Transform _bulletSpawner;
	[SerializeField] private float _timeBetweenShoots = 1f;

	[Space(3)]
	[Header("Reload and ammo")]
	[SerializeField] private AudioClip _reloadSound;
	[SerializeField] private float _reloadTime = 5f;
	[SerializeField] private int _magazineSize = 9;

	[Space(5)]
	[Header("Debug")]
	[SerializeField] private Transform _target;

	private AudioSource _audioSource;
	private SpriteRotator _spriteRotator;
	private SpriteRenderer _weaponRenderer;
	private int _ammoCount;
	private float _cantShootNextSeconds = 0f;
	public void SetTarget(Transform target)
	{
		_target = target;
	}
	public void Attack()
	{
		if (_cantShootNextSeconds > 0)
		{
			return;
		}
		if (_ammoCount <= 0)
		{
			Reload();
			return;
		}

		_ammoCount -= 1;
		_cantShootNextSeconds = _timeBetweenShoots;
		Instantiate(_bullet, _bulletSpawner.position, _bulletSpawner.rotation);

		_audioSource.clip = _shootSound;
		_audioSource.Play();
	}
	public void Aim()
	{
		_spriteRotator.RotateBody(_target.position.x - transform.position.x > 0 ? Direction.Right : Direction.Left);
		_weaponRenderer.flipY = _spriteRotator.Direction == Direction.Left;
		_weapon.right = _target.transform.position - _weapon.position;
	}
	public void Reload()
	{
		_cantShootNextSeconds += _reloadTime;
		_ammoCount = _magazineSize;

		_audioSource.clip = _reloadSound;
		_audioSource.Play();
	}
	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_weaponRenderer = _weapon.GetComponent<SpriteRenderer>();
		_spriteRotator = GetComponent<SpriteRotator>();
		_ammoCount = _magazineSize;
}
	private void FixedUpdate()
	{
		if (_cantShootNextSeconds > 0)
		{
			_cantShootNextSeconds -= Time.fixedDeltaTime;
		}
	}
}

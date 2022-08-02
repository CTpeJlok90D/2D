using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(SpriteRotator))]
public class AIShoot : MonoBehaviour
{
	[Header("Shooting")]
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _bulletSpawner;
	[SerializeField] private float _timeBetweenShoots = 1f;

	[Space(3)][Header("Reload and ammo")]
	[SerializeField] private AudioClip _reloadSound;
	[SerializeField] private float _reloadTime = 5f;
	[SerializeField] private int _magazineSize = 9;

	private int _ammoCount;
	private float _cantShootNextSeconds = 0f;
	private AudioSource _audioSource;
	private SpriteRotator _spriteRotator;
	private Transform _target;

	public void SetTarget(Transform target)
	{
		_target = target;
	}
	public void Attack(Transform target)
	{
		_target = target;
		Attack();
	}
	public void Attack()
	{
		if (_ammoCount <= 0)
		{
			Reload();
			return;
		}
		Aim();
		if (_cantShootNextSeconds > 0)
		{
			return;
		}

		_ammoCount -= 1;
		_cantShootNextSeconds = _timeBetweenShoots;
		Instantiate(_bullet, _bulletSpawner.position, _bulletSpawner.rotation);
	}
	public void Reload()
	{
		_cantShootNextSeconds += _reloadTime;
		_ammoCount = _magazineSize;

		_audioSource.clip = _reloadSound;
		_audioSource.Play();
	}
	private void Aim()
	{
		_spriteRotator.RotateAll(_target.position.x - transform.position.x);
		_spriteRotator.RotateItems(_target);
	}
	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
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

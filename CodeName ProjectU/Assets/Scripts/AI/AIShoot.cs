using UnityEngine;

[RequireComponent(typeof(AudioSource),typeof(AIMove))]
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
	[SerializeField] private int _maxAmmoCount = 9;
	[SerializeField] private int _ammoCount = 9;

	[Space(5)]
	[Header("Debug")]
	[SerializeField] private Transform _target;
	private float _cantShootNextSeconds = 0f;
	private AudioSource _audioSource;
	private AIMove _aiMove;
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
		_aiMove.Rotate(_target.transform.position.x - _weapon.position.x > 0 ? 1 : -1);
		_weapon.right = _target.transform.position - _weapon.position;
	}
	public void Reload()
	{
		_cantShootNextSeconds += _reloadTime;
		_ammoCount = _maxAmmoCount;

		_audioSource.clip = _reloadSound;
		_audioSource.Play();
	}
	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_aiMove = GetComponent<AIMove>();
	}
	private void Update()
	{
		Aim();
		Attack();
	}
	private void FixedUpdate()
	{
		if (_cantShootNextSeconds > 0)
		{
			_cantShootNextSeconds -= Time.fixedDeltaTime;
		}
	}
}

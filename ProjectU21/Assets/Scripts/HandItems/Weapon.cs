using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class Weapon : UsebleItem, IAlternativeUsevleItem
{
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private Scope _scope;
    [SerializeField] private AudioClip _reloadSound;
    [SerializeField] private AudioClip _noAmmoSound;
    [SerializeField] private GameObject _hitEffect;

    [SerializeField] private Vector2 _cameraImpact = new Vector2(0.2f,0);
    [SerializeField] private float _recoil = 0.1f;
    [SerializeField] private float _accusity = 1f;
    [SerializeField] private float _aimMaxDistanse = 10f;
    [SerializeField] private float _timeBetweenShoots = 0.1f;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private float _shootDistace = 15;
    [SerializeField] private int _magazineSize = 30;
    [SerializeField] private UnityEvent _ammoIsOut = new();

    private AudioSource _audioSource;
    private bool _reloading = false;
    private int _corentAmmoCount = 0;
    private float _cantShootNextSeconds = 0f;
    private bool _shooting;
    private bool _aiming;
    private PlayerCamera _camera;

    public float Accusity => _accusity;
    public float AimMaxDistanse => _aimMaxDistanse;
    public float Recoil => _recoil;
    public bool CanShoot => _corentAmmoCount > 0 && _cantShootNextSeconds <= 0;
    public int AmmoCount => _corentAmmoCount;
    public Vector2 CameraImpact => _cameraImpact;
    public float ShootDistance => _shootDistace;
    public RaycastHit2D[] OnGunPoint => Physics2D.RaycastAll(_bulletSpawner.transform.position, _bulletSpawner.transform.right, _shootDistace);
    public Scope Scope => _scope;

    public override void Use(InputAction.CallbackContext context)
    {
        _shooting = context.canceled == false;
    }

    public void AlternativeUse(InputAction.CallbackContext context)
    {
        _aiming = context.canceled == false;
    }

    public void Init(Scope scope)
    {
        _scope = scope;
    }

    private void Shoot()
    {
        if (CanShoot == false)
        {
            if (_corentAmmoCount <= 0)
            {
                NoAmmoEvent();
            }
            return;
        }
        _scope.AddRecoilPower(_recoil);
        _camera.AddImpact(_cameraImpact);
        _cantShootNextSeconds += _timeBetweenShoots;
        _corentAmmoCount -= 1;
        SpawnBullet();
    }

    private void Reload()
    {
        if (_reloading || _corentAmmoCount == _magazineSize)
        {
            return;
        }
        _reloading = true;
        _cantShootNextSeconds += _reloadTime;
        _corentAmmoCount = _magazineSize;

        _audioSource.clip = _reloadSound;
        _audioSource.Play();
    }
    
    private void SpawnBullet()
    {
        Instantiate(_bulletPrefab, _bulletSpawner.transform.position, _bulletSpawner.transform.rotation);
        foreach (RaycastHit2D hit in OnGunPoint)
        {
            Instantiate(_hitEffect, hit.point, new Quaternion(hit.normal.x, hit.normal.y, 0, 0));
        }
    }

    private void NoAmmoEvent()
    {
        _audioSource.clip = _noAmmoSound;
        _audioSource.Play();
        _ammoIsOut.Invoke();
    }


    private void Aim()
    {
        if (_aiming)
        {
            _camera.SetTarget(_scope.transform);
        }
        else
        {
            _camera.BackToMainTarget();
        }

    }

    private void FixedUpdate()
    {
        if (_shooting)
        {
            Shoot();
        }
        Aim();

        _cantShootNextSeconds = Mathf.Clamp(_cantShootNextSeconds - Time.fixedDeltaTime, 0, Mathf.Infinity);
        if (_reloading)
        {
            _reloading = _cantShootNextSeconds > 0;
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _camera = Camera.main.GetComponent<PlayerCamera>();
        _corentAmmoCount = _magazineSize;
    }

    private void Start()
    {
        if (_corentAmmoCount <= 0)
        {
            _ammoIsOut.Invoke();
        }
    }
}
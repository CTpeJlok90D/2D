using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _bullet;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private AudioClip _reloadSound;
    [SerializeField] private AudioClip _noAmmoSound;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private SpriteRotator _spriteRotator;

    [SerializeField] private Vector2 _cameraImpact = new Vector2(0.2f,0);
    [SerializeField] private float _recoil = 0.1f;
    [SerializeField] private float _accusity = 1f;
    [SerializeField] private float _aimMaxDistanse = 10f;
    [SerializeField] private float _timeBetweenShoots = 0.1f;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private float _shootDistace = 15;
    [SerializeField] private int _magazineSize = 30;

    private AudioSource _audioSource;
    private bool _reloading = false;
    private int _correctAmmoCount;
    private float _cantShootNextSeconds = 0f;

    public float Accusity => _accusity;
    public float AimMaxDistanse => _aimMaxDistanse;
    public float Recoil => _recoil;
    public bool CanShoot => _correctAmmoCount > 0 && _cantShootNextSeconds <= 0;
    public int AmmoCount => _correctAmmoCount;
    public Vector2 CameraImpact => _cameraImpact;
    public RaycastHit2D[] OnGunPoint => Physics2D.RaycastAll(_bulletSpawner.transform.position, _bulletSpawner.transform.right, _shootDistace);

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void Shoot()
    {
        if (CanShoot)
        {
            _cantShootNextSeconds += _timeBetweenShoots;
            _correctAmmoCount -= 1;
            Instantiate(_bullet, _bulletSpawner.transform.position, _bulletSpawner.transform.rotation);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(_bulletSpawner.transform.position, _bulletSpawner.transform.right, _shootDistace);
            foreach (RaycastHit2D hit in OnGunPoint)
            {
                Instantiate(_hitEffect, hit.point, new Quaternion(raycastHit2D.normal.x, raycastHit2D.normal.y, 0, 0));
            }
            return;
        }
        if (_correctAmmoCount == 0)
        {
            _audioSource.clip = _noAmmoSound;
            _audioSource.Play();
        }
    }
    public void Reload()
    {
        if (_reloading || _correctAmmoCount == _magazineSize)
        {
            return;
        }
        _reloading = true;
        _cantShootNextSeconds += _reloadTime;
        _correctAmmoCount = _magazineSize;

        _audioSource.clip = _reloadSound;
        _audioSource.Play();
    }
    private void FixedUpdate()
    {
        _cantShootNextSeconds = Mathf.Clamp(_cantShootNextSeconds - Time.fixedDeltaTime, 0, Mathf.Infinity);
        if (_reloading)
        {
            _reloading = _cantShootNextSeconds > 0;
        }
    }

}
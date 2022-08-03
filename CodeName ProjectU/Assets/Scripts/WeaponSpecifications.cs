using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class WeaponSpecifications : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _reloadSound;
    [SerializeField] private AudioClip _noAmmoSound;

    [SerializeField] private float _recoil = 1f;
    [SerializeField] private float _accusity = 1f;
    [SerializeField] private float _accusityMaxDistanse = 10f;
    [SerializeField] private float _timeBetweenShoots = 0.1f;
    [SerializeField] private float _reloadTime = 3f;
    [SerializeField] private int _magazineSize = 30;

    private AudioSource _audioSource;
    private int _correctAmmoCount;
    private float _cantShootNextSeconds = 0f;
    public float Accusity => _accusity;
    public float AccusityMaxDistanse => _accusityMaxDistanse;
    public float Recoil => _recoil;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public bool CanShoot() => _correctAmmoCount > 0 && _cantShootNextSeconds > 0;
    public void Shoot()
    {
        if (CanShoot())
        {
            _cantShootNextSeconds += _timeBetweenShoots;
            _correctAmmoCount -= 1;
            Instantiate(_bullet, _bulletSpawner.position, _bulletSpawner.rotation);
            _audioSource.clip = _shootSound;
            _audioSource.Play();
            return;
        }
        _audioSource.clip = _noAmmoSound;
        _audioSource.Play();
    }
    public void Reload()
    {
        _cantShootNextSeconds += _reloadTime;
        _correctAmmoCount = _magazineSize;

        _audioSource.clip = _reloadSound;
        _audioSource.Play();
    }
}

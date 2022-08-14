using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRotator), typeof(Specifications))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Scope _scope;
    [SerializeField] private SmoothCopyTransform _camera;
    [SerializeField] private Weapon _weapon;

    private bool _aiming = false;
    private bool _shooting = false;
    private SpriteRotator _spriteRotator;
    private Specifications _specifications;

    public bool Aiming => _aiming;
    public bool Armed => _weapon != null;

    public void Aim(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _aiming = false;
            return;
        }
        _aiming = true;
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _shooting = false;
            return;
        }
        _shooting = true;
    }
    public void Reload(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }
        _weapon.Reload();
    }
    private void Aim()
    {
        _spriteRotator.RotateItems(_scope.transform.position, _weapon.Accusity);
        _spriteRotator.InvertItems(_scope.transform.position.x - transform.position.x);
        if (Aiming)
        {
            _camera.SetTarget(_scope.transform);
        }
        else
        {
            _camera.SetTarget(transform);
        }
    }
    private void Shoot()
    {
        if (_weapon.CanShoot && _shooting)
        {
            Camera.main.transform.position += new Vector3(-_weapon.CameraImpact.x * _spriteRotator.Direction, -_weapon.CameraImpact.y, 0);
            _scope.AddRecoilPower(_weapon.Recoil * (Aiming ? _specifications.AimRecoilMultiply : 1f));
            _weapon.Shoot();
        }
    }
    private void Awake()
    {
        _spriteRotator = GetComponent<SpriteRotator>();
        _specifications = GetComponent<Specifications>();
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Armed)
        {
            Aim();
            Shoot();
        }
    }
}

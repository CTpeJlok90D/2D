using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRotator), typeof(Specifications))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Texture2D _aimCursor;
    [SerializeField] private Scope _scope;
    [SerializeField] private SmoothCopyTransform _camera;
    [SerializeField] private WeaponSpecifications _weaponSpecifications;

    private PlayerShootInput _playerShoot;
    private InputAction _aim;

    private SpriteRotator _spriteRotator;
    private Specifications _specifications;
    private void Awake()
    {
        _spriteRotator = GetComponent<SpriteRotator>();
        _specifications = GetComponent<Specifications>();
        Cursor.SetCursor(_aimCursor, Vector2.zero, CursorMode.Auto);

        _playerShoot = new PlayerShootInput();
        _playerShoot.Enable();
        _aim = _playerShoot.Player.Aim;
    }
    private void Update()
    {
        Aim();
    }
    private void Aim()
    {
        _spriteRotator.RotateItems(_scope.transform, _weaponSpecifications.Accusity);
        _spriteRotator.RotateAll(_scope.transform.position.x - transform.position.x);
        if (_aim.ReadValue<float>() > 0)
        {
            _camera.SetTarget(_scope.transform);
        }
        else
        {
            _camera.SetTarget(transform);
        }
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        _weaponSpecifications.Shoot();
        if (_weaponSpecifications.CanShoot())
        {
            _scope.AddRecoilPower(_weaponSpecifications.Recoil);
        }
    }
    public void Reload(InputAction.CallbackContext context)
    {
        _weaponSpecifications.Reload();
    }
}

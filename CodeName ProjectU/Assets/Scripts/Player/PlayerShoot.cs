using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRotator), typeof(Specifications))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Scope _scope;
    [SerializeField] private SmoothCopyTransform _camera;
    [SerializeField] private Weapon _weapon;

    private PlayerMove _playerInput;
    private InputAction _aim;
    private InputAction _shoot;
    private InputAction _reload;

    private SpriteRotator _spriteRotator;
    private Specifications _specifications;

    public bool Aiming => _aim.ReadValue<float>() > 0;

    private void Awake()
    {
        _spriteRotator = GetComponent<SpriteRotator>();
        _specifications = GetComponent<Specifications>();
        Cursor.visible = false;

        _playerInput = new PlayerMove();
        _playerInput.Enable();
        _aim = _playerInput.Player.Aim;
        _shoot = _playerInput.Player.Shoot;
        _reload = _playerInput.Player.Reload;
    }
    private void Update()
    {
        Aim();
        if (_shoot.ReadValue<float>() > 0)
        {
            Shoot();
        }
        if (_reload.ReadValue<float>() > 0)
        {
            Reload();
        }
    }
    private void Aim()
    {
        _spriteRotator.RotateItems(_scope.transform.position, _weapon.Accusity);
        _spriteRotator.RotateBody(_scope.transform.position.x - transform.position.x);
        if (Aiming)
        {
            _camera.SetTarget(_scope.transform);
        }
        else
        {
            _camera.SetTarget(transform);
        }
    }
    public void Shoot()
    {
        if (_weapon.CanShoot)
        {
            Camera.main.transform.position += new Vector3(-_weapon.CameraImpact.x * _spriteRotator.Direction, -_weapon.CameraImpact.y, 0);
            _scope.AddRecoilPower(_weapon.Recoil * (Aiming ? _specifications.AimRecoilMultiply : 1f));
        }
        _weapon.Shoot();
    }
    public void Reload()
    {
        _weapon.Reload();
    }
}

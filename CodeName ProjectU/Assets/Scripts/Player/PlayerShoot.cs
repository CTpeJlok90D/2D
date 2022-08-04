using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRotator), typeof(Specifications))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Texture2D _aimCursor;
    [SerializeField] private Scope _scope;
    [SerializeField] private SmoothCopyTransform _camera;
    [SerializeField] private Weapon _weapon;

    [SerializeField] private float _aimRecoilMultiply = 0.5f;

    private PlayerMove _playerInput;
    private InputAction _aim;
    private InputAction _shoot;
    private InputAction _reload;

    private SpriteRotator _spriteRotator;

    public bool Aiming => _aim.ReadValue<float>() > 0;

    private void Awake()
    {
        _spriteRotator = GetComponent<SpriteRotator>();
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
        _spriteRotator.RotateItems(_scope.transform, _weapon.Accusity);
        _spriteRotator.RotateAll(_scope.transform.position.x - transform.position.x);
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
            _scope.AddRecoilPower(_weapon.Recoil * (Aiming ? _aimRecoilMultiply : 1f));
        }
        _weapon.Shoot();
    }
    public void Reload()
    {
        _weapon.Reload();
    }
}

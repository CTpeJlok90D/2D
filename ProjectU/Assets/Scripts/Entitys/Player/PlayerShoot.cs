using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : BaseShooting
{
    [SerializeField] private SmoothCopyTransform _camera;

    private bool _aiming = false;
    private bool _shooting = false;

    public bool Aiming => _aiming;

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
        Weapon.Reload();
    }

    private void Aim()
    {
        if (Aiming)
        {
            _camera.SetTarget(Weapon.transform);
        }
        else
        {
            _camera.SetTarget(transform);
        }
    }

    private void Update()
    {
        Aim();
        if (_shooting)
        {
            Shoot();
        }
    }
}

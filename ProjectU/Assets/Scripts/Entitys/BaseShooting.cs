using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootingSpecifications))]
public class BaseShooting : MonoBehaviour
{
    [SerializeField] private Scope _scope;
    [SerializeField] private Weapon _weapon;

    private ShootingSpecifications _specifications;

    protected Weapon Weapon => _weapon;

    public void Shoot()
    {
        if (_weapon.CanShoot == false)
        {
            return;
        }
        _scope.AddRecoilPower(_weapon.Recoil * _specifications.AimSkill);
        _weapon.Shoot();
    }

    public void Reload()
    {
        _weapon.Reload();
    }
}

using UnityEngine;


namespace Weapons 
{
    public class Rifle : Weapon
    {
        [SerializeField] private Transform _bulletSpawnpoint;
        [SerializeField] private float _range;
        [SerializeField] private GameObject _bulletholePrefub;

        public override void Use()
        {
            RaycastHit2D hit = Physics2D.Raycast(_bulletSpawnpoint.position, _bulletSpawnpoint.up, _range);
            Instantiate(_bulletholePrefub, hit.point, Quaternion.identity);
        }
    }
}

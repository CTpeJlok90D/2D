using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _distance;
    [SerializeField] private GameObject _hitEffect;
    private void Awake()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.right, _distance);
        if (raycastHit2D)
        {
            Instantiate(_hitEffect, raycastHit2D.point, new Quaternion(raycastHit2D.normal.x, raycastHit2D.normal.y, 0,0));
        }
        Destroy(this.gameObject);
    }
}

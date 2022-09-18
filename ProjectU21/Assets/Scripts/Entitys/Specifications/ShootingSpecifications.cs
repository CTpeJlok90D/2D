using UnityEngine;

public class ShootingSpecifications : MonoBehaviour
{
    [SerializeField] private float _aimSkill;

    public float AimSkill => _aimSkill;
}
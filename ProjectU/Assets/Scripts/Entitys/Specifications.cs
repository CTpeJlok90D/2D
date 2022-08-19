using UnityEngine.Events;
using UnityEngine;

public class Specifications : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _health = 10;
    [SerializeField] private UnityEvent _death;
    [Header("Move")]
    [SerializeField] private float _maxWalkSpeed = 1f;
    [SerializeField] private float _maxSprintSpeed = 3f;
    [SerializeField] private float _walkBoost = 0.8f;
    [SerializeField] private float _sprintBoost = 1.1f;
    [SerializeField] private float _brakingForce = 0.8f;
    [SerializeField] private AnimationCurve _jumpForseCuvre;
    [Header("Shooting")]
    [SerializeField] private float _aimRecoilMultiply = 0.5f;
    [SerializeField] private float _aimSkill = 1f;

    public float MaxWalkSpeed => _maxWalkSpeed;
    public float MaxSprintSpeed => _maxSprintSpeed;
    public float WalkBoost => _walkBoost;
    public float SprintBoost => _sprintBoost;
    public float BrakingForce => _brakingForce;
    public AnimationCurve JumpForseCurve => _jumpForseCuvre;

    public int MaxHealth => _maxHealth;
    public int Health => _health;  
    public UnityEvent Death => _death;   

    public float AimRecoilMultiply => _aimRecoilMultiply;
    public float AimSkill => _aimSkill;

    public void ApplyHealthValue(int healPointCount)
    {
        _health = Mathf.Clamp(_health + healPointCount, 0, _maxHealth);
        if (_health <= 0)
        {
            _death.Invoke();
        }
    }
}

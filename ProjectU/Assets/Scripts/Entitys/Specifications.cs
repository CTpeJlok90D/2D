using UnityEngine.Events;
using UnityEngine;

public class Specifications : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _health = 10;
    [SerializeField] private UnityEvent _death;
    [Header("Shooting")]
    [SerializeField] private float _aimRecoilMultiply = 0.5f;
    [SerializeField] private float _aimSkill = 1f;

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

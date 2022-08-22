using UnityEngine;

public class MoveSpecifications : MonoBehaviour
{
    [SerializeField] private float _maxWalkSpeed = 1f;
    [SerializeField] private float _maxSprintSpeed = 3f;
    [SerializeField] private float _walkBoost = 0.8f;
    [SerializeField] private float _sprintBoost = 1.1f;
    [SerializeField] private float _brakingForce = 0.8f;
    [SerializeField] private float _jumpColldown = 0.05f;
    [SerializeField] private AnimationCurve _jumpForseCuvre;

    public float MaxWalkSpeed => _maxWalkSpeed;
    public float MaxSprintSpeed => _maxSprintSpeed;
    public float WalkBoost => _walkBoost;
    public float SprintBoost => _sprintBoost;
    public float BrakingForce => _brakingForce;
    public float JumpCooldown => _jumpColldown;
    public AnimationCurve JumpForseCurve => _jumpForseCuvre;
}
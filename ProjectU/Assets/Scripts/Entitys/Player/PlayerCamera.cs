using UnityEngine;

public class PlayerCamera : SmoothCopyTransform
{
    [SerializeField] private PlayerRotator _playerRotator;
    private Transform _mainTarget;

    public void BackToMainTarget()
    {
        SetTarget(_mainTarget);
    }

    public void AddImpact(Vector2 impact)
    {
        transform.position += (Vector3)impact * -_playerRotator.LookDirection;
    }

    private void Awake()
    {
        _mainTarget = _target;
    }
}
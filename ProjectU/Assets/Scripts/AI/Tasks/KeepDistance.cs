using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AIMove))]
public class KeepDistance : Task
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minDistance;
    [SerializeField] private UnityEvent _onDistanse;

    private AIMove _aiMove;

    public float MaxDistance => _maxDistance;
    public float MinDistance => _minDistance;
    public float AverageDistanse => (_maxDistance + _minDistance) / 2;
    public bool OnDistase
    { 
        get 
        {
            float correctDistance = Vector2.Distance(transform.position, _target.position);
            return correctDistance < _maxDistance && correctDistance > _minDistance;
        }
    }

    public override void DoIt()
    {
        if (OnDistase == false)
        {
            _aiMove.GoTo(_target.position.x + Mathf.Clamp(_target.position.x - transform.position.x, -1, 1) * -AverageDistanse);
            return;
        }
        _onDistanse.Invoke();
    }

    protected override void Awake()
    {
        base.Awake();
        _aiMove = GetComponent<AIMove>();
    }
    private void OnValidate()
    {
        if (_maxDistance < _minDistance)
        {
            _maxDistance = _minDistance;
        }
    }
}

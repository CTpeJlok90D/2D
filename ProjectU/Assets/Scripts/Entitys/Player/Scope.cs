using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _standartMaxDistance = 5f;

    private float _accusity;
    private float _maxDistance;

    private float _recoilPower = 0f;

    public void AddRecoilPower(float power)
    {
        _recoilPower = power + _recoilPower > 0 ? power + _recoilPower : 0;
    }

    public void SetAccusity(Weapon weapon)
    {
        _accusity = weapon.Accusity;
    }

    public void ResetAccusity()
    {
        _accusity = 1;
    }

    private void Cursor()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 _positiveMaxPosition = new Vector2(_center.position.x + _maxDistance, _center.position.y + _maxDistance);
        Vector2 _negativeMaxPosition = new Vector2(_center.position.x - _maxDistance, _center.position.y - _maxDistance);
        for (int i = 0; i < 2; i++)
        {
            if (target[i] > _positiveMaxPosition[i] || target[i] < _negativeMaxPosition[i])
            {
                target[i] = target[i] > _positiveMaxPosition[i] ? _positiveMaxPosition[i] : _negativeMaxPosition[i];
            }
        }
        Vector3 _targetPosition = Vector3.MoveTowards(transform.position, target, _accusity);
        transform.position = new Vector3(_targetPosition.x, _targetPosition.y + _recoilPower);
    }

    private void Update()
    {
        Cursor();

        _recoilPower = Mathf.Clamp(_recoilPower - Time.deltaTime, 0, Mathf.Infinity);
    }

    private void Awake()
    {
        _accusity = 1f;
        _maxDistance = _standartMaxDistance;
    }
}

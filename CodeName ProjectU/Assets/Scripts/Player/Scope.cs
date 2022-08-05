using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    [SerializeField] private Transform _mainCharacter;
    [SerializeField] private Weapon _specifications;

    private float _recoilPower = 0f;

    public void AddRecoilPower(float power)
    {
        _recoilPower = power + _recoilPower > 0 ? power + _recoilPower : 0;
    }

    private void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 _positiveMaxPosition = new Vector2(_mainCharacter.position.x + _specifications.AimMaxDistanse, _mainCharacter.position.y + _specifications.AimMaxDistanse);
        Vector2 _negativeMaxPosition = new Vector2(_mainCharacter.position.x - _specifications.AimMaxDistanse, _mainCharacter.position.y - _specifications.AimMaxDistanse);
        for (int i = 0; i < 2; i++)
        {
            if (target[i] > _positiveMaxPosition[i] || target[i] < _negativeMaxPosition[i])
            {
                target[i] = target[i] > _positiveMaxPosition[i] ? _positiveMaxPosition[i] : _negativeMaxPosition[i];
            }
        }
        Vector3 _targetPosition = Vector3.MoveTowards(transform.position, target, _specifications.Accusity);
        transform.position = new Vector3(_targetPosition.x, _targetPosition.y + _recoilPower, transform.position.z);
        _recoilPower = _recoilPower - Time.deltaTime > 0 ? _recoilPower - Time.deltaTime : 0;
    }
}

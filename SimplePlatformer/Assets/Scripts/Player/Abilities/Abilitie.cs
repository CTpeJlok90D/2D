using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private float _coolDown = 3f;
    private float _currentCooldown = 0f;
    
    protected bool CanUse => _currentCooldown == 0f;
    protected float CurrentCooldown => _currentCooldown;

    public void Use()
    {
        if (CanUse)
        {
            Execute();
            _currentCooldown = _coolDown;
        }
    }

    private void FixedUpdate()
    {
        ReduceCoolDown();
    }

    protected abstract void Execute();

    protected virtual void ReduceCoolDown()
    {
        _currentCooldown = Mathf.Clamp(_currentCooldown-Time.fixedDeltaTime, 0, Mathf.Infinity);
    } 
}
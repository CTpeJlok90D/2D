using UnityEngine;
using UnityEngine.Events;

public class Reload : Task
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private UnityEvent _reloaded;

    public override void DoIt()
    {
        _weapon.Reload();
        _reloaded.Invoke();
    }
}

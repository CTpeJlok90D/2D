using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private List<BodyPart> _bodyParts = new();
    [SerializeField] private UnityEvent _death = new();
    [SerializeField] private float _consumeOxygenPerSecond = 10f;

    private Dictionary<HealthParametr, LimitedValue> _lifeNeedProperutes = new()
    {
        [HealthParametr.BloodLevel] = new(100, 100, 0),
        [HealthParametr.BloodFiltration] = new(100, 100, 0),
        [HealthParametr.BloodPumping] = new(100, 100, 0),
        [HealthParametr.OxygerLevel] = new(100, 100, 0),
        [HealthParametr.HungerLevel] = new(100,100,0)
    };

    public enum HealthParametr 
    {
        BloodLevel,
        BloodFiltration,
        BloodPumping,
        OxygerLevel,
        HungerLevel
    }

    public void ApplyInfluence(Influence influence)
    {
        if (IsDead())
        {
            _death.Invoke();
        }
    }

    private bool IsDead()
    {
        foreach (LimitedValue var in _lifeNeedProperutes.Values)
        {
            if (var == 0)
            {
                return true;
            }
        }
        return false;
    }
}
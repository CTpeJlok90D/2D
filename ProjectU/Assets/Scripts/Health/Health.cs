using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private List<BodyPart> _bodyParts = new();
    [SerializeField] private UnityEvent _death = new();
    [SerializeField] private float _consumeOxygenPerSecond = 10f;

    private LimitedValue _bloodLevel = new(100,100,0);
    private LimitedValue _bloodFiltration = new(100, 100, 0);
    private LimitedValue _bloodPumping = new(100, 100, 0);
    [SerializeField] private LimitedValue _oxygenLevel = new(100, 100, 0);
    private LimitedValue _hungerlevel = new(50, 100, 0);

    private void UpdateOxygenStorage()
    {
        float newMax = 0f;
        foreach (BodyPart var in _bodyParts)
        {
            newMax += var.GivingOxygenStorage;
        }
        _oxygenLevel.SetNewMax(newMax);
    }

    private void Breath()
    {
        _oxygenLevel -= _consumeOxygenPerSecond * Time.fixedDeltaTime;
        foreach (BodyPart var in _bodyParts)
        {
            _oxygenLevel += var.GivingOxygen * Time.fixedDeltaTime;
            Debug.Log(_oxygenLevel);
        }
    }

    private void FixedUpdate()
    {
        Breath();
    }

    private void Awake()
    {
        UpdateOxygenStorage();
    }
}

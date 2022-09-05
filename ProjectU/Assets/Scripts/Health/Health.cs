using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private List<Influence> _bodyParts = new();
    [SerializeField] private UnityEvent _death = new();
    [SerializeField] private float _consumeOxygenPerSecond = 10f;

    private LimitedValue _bloodLevel = new(100,100,0);
    private LimitedValue _bloodFiltration = new(100, 100, 0);
    private LimitedValue _bloodPumping = new(100, 100, 0);
    private LimitedValue _oxygenLevel = new(100, 100, 0);
    private LimitedValue _hungerlevel = new(50, 100, 0);
}

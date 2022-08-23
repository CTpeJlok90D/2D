using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerRotator : SpriteRotator
{
    [SerializeField] private Scope _scope;

    private int _lookDirection = 1;
    private UnityEvent _rotate = new();

    private void UpdateLookDirection()
    {
        int correctDirection = (_scope.transform.position.x - transform.position.x) > 0 ? 1 : -1;
        if (_lookDirection != correctDirection)
        {
            _lookDirection = correctDirection;
            _rotate.Invoke();
        }
    }

    private void Update()
    {
        LookAt(_scope.transform);
        UpdateLookDirection();
    }

    private void OnEnable()
    {
        _rotate.AddListener(Rotate);
    }

    private void OnDisable()
    {
        _rotate.RemoveListener(Rotate);
    }
}

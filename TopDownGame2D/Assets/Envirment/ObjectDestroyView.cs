using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyView : MonoBehaviour
{
    [SerializeField] private Health.Health _health;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Header("Int-Sprite dictionary")]
    [SerializeField] private List<int> _keys = new();
    [SerializeField] private List<Material> _value = new();

    private void Awake()
    {
        _health.CurrentChanged.AddListener(OnCurrentHealthChanged);
        if (_keys.Count != _value.Count)
        {
            Debug.LogError("Error intput value. Cant convert to dictionary");
        }
    }

    private void OnCurrentHealthChanged(int current)
    {
        for (int i = 0; i < _keys.Count; i++)
        {
            if (current < _keys[i])
            {
                _spriteRenderer.material = _value[i];
                return;
            }
        }
    }
}

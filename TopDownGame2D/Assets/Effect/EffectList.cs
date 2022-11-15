using System.Collections.Generic;
using UnityEngine;
using Effects;
using UnityEngine.Events;

public class EffectList : MonoBehaviour
{
    [SerializeField] private UnityEvent<Impact> _effectTick;

    private Impact _resultImpact = new Impact();
    private List<Effect> _effects = new List<Effect>();

    public void Add(Effect newEffect)
    {
        _effects.Add(newEffect);
    }

    private void AppllyEffectsImpact()
    {
        _resultImpact = new Impact() { };
        foreach (Effect effect in _effects)
        {
            _resultImpact += effect.GetImpact();
        }
        ApplyResultImpact();
    }

    private void ReduseEffectCooldown()
    {
        foreach (Effect effect in _effects.ToArray())
        {
            effect.RemoveDiruration(Time.deltaTime);
            if (effect.Diruration <= 0)
            {
                _effects.Remove(effect);
            }
        }
    }

    private void ApplyResultImpact()
    {
        _effectTick.Invoke(_resultImpact);
    }

    private void Update()
    {
        AppllyEffectsImpact();
        ReduseEffectCooldown();
    }
}

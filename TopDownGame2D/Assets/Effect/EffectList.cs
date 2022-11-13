using System.Collections.Generic;
using UnityEngine;
using Health;
using Effects;
using Character;

public class EffectList : MonoBehaviour
{
    [SerializeField] private TopDownCharacter2D _characterController;
    [SerializeField] private CharacterHealth _health;

    private Impact _resultImpact = new Impact();
    private List<Effect> _effects = new List<Effect>();

    public void Add(Effect newEffect)
    {
        _effects.Add(newEffect);
    }

    private void AppllyEffectsImpact()
    {
        _resultImpact = new Impact() { SpeedMultiplier = 1f, JumpForseMultiplier = 1f };
        foreach (Effect effect in _effects)
        {
            _resultImpact += effect.GetImpact();
        }
        ApplyResultImpact();
    }

    private void ReduseEffectCoolDown()
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
        
    }

    private void Update()
    {
        AppllyEffectsImpact();
        ReduseEffectCoolDown();
    }
}

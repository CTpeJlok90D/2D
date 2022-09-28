using System.Collections.Generic;
using UnityEngine;
using Health;
using Effects;

public class CharacterEffectList : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private CharacterHealth _health;

    private Impact _resultImpact = new();
    private List<Effect> _effects = new();

    public void Add(Effect newEffect)
    {
        _effects.Add(newEffect);
    }

    private void AppllyEffectsImpact()
    {
        _resultImpact = new() { SpeedMultiplier = 1f, JumpForseMultiplier = 1f };
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
        _characterController.SetActiveControl(_resultImpact.Stun == false);
        if (_health.Invulnerability == false)
        {
            _health.Current += _resultImpact.HealValue;
        }
        _health.Invulnerability = _resultImpact.Invulnerability;
        if (_resultImpact.Kick != Vector2.zero)
        {
            _characterController.Kick(_resultImpact.Kick);
        }
        _characterController.JumpForseMultiplier = _resultImpact.JumpForseMultiplier;
        _characterController.SpeedMultiplier = _resultImpact.SpeedMultiplier;
    }

    private void Update()
    {
        AppllyEffectsImpact();
        ReduseEffectCoolDown();
    }
}

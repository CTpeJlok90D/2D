using System.Collections.Generic;
using UnityEngine;
using Health;
using Effects;

public class EffectList : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private CharacterHealth _health;

    private Impact _resultImpact = new();
    private List<Effect> _effects = new();
    private bool _stunned = false;

    public bool Stunned => _stunned;

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
        _stunned = _resultImpact.Stun;
        _characterController.SetActiveControl(_stunned == false);
        if (_health.Invulnerability == false)
        {
            _health.Current += _resultImpact.HealValue;
        }
        if (_resultImpact.Kick != Vector2.zero && _health.Invulnerability == false)
        {
            _characterController.Kick(_resultImpact.Kick);
        }
        _health.Invulnerability = _resultImpact.Invulnerability;
        _characterController.JumpForseMultiplier = _resultImpact.JumpForseMultiplier;
        _characterController.SpeedMultiplier = _resultImpact.SpeedMultiplier;
    }

    private void Update()
    {
        AppllyEffectsImpact();
        ReduseEffectCoolDown();
    }
}

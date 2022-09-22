using System.Collections.Generic;
using UnityEngine;
using Health;

public class CharacterEffectList : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private CharacterHealth _health;

    private Impact resultImpact = new();
    private List<Effect> _effects = new();

    public void Add(Effect newEffect)
    {
        _effects.Add(newEffect);
    }

    private void AppllyEffectsImpact()
    {
        resultImpact = new() { SpeedMultiplier = 1f, JumpForseMultiplier = 1f };
        foreach (Effect effect in _effects)
        {
            resultImpact += effect.GetImpact();
        }
        ApplyResultImpact();
    }

    private void ReduseEffectCoolDown()
    {
        foreach (Effect effect in _effects.ToArray())
        {
            effect.RemoveDiruration(Time.fixedDeltaTime);
            if (effect.Diruration <= 0)
            {
                _effects.Remove(effect);
            }
        }
    }

    private void ApplyResultImpact()
    {
        _characterController.SetControlActive(resultImpact.Stun == false);
        _health.Invulnerability = resultImpact.Invulnerability;
        _health.Current += resultImpact.HealValue;
        if (resultImpact.Kick != Vector2.zero)
        {
            _characterController.Kick(resultImpact.Kick);
        }
        _characterController.JumpForseMultiplier = resultImpact.JumpForseMultiplier;
        _characterController.SpeedMultiplier = resultImpact.SpeedMultiplier;
    }

    private void FixedUpdate()
    {
        AppllyEffectsImpact();
        ReduseEffectCoolDown();
    }
}

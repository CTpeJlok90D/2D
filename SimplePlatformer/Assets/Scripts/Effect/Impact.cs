using System;
using UnityEngine;

[Serializable]
public class Impact
{
    public bool Stun = false;
    public bool StunImmunitete = false;
    public bool Invulnerability = false;
    public float SpeedMultiplier = 0f;
    public float JumpForseMultiplier = 0f;
    public int HealValue = 0;
    public Vector2 Kick = new();

    public static Impact operator +(Impact a, Impact b)
    {
        return new Impact() 
        {
            Stun = a.Stun || b.Stun,
            StunImmunitete = a.StunImmunitete || b.StunImmunitete,
            Invulnerability = a.Invulnerability || b.Invulnerability,
            HealValue = a.HealValue + b.HealValue,
            Kick = a.Kick + b.Kick,
            SpeedMultiplier = a.SpeedMultiplier + b.SpeedMultiplier,
            JumpForseMultiplier = a.JumpForseMultiplier + b.JumpForseMultiplier,
        };
    }
}
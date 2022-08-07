using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpecifications : Specifications
{
    [SerializeField] private float _aimTime = 1f;

    public float AimTime => _aimTime;
}

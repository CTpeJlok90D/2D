using System;
using UnityEngine;

[Serializable]
public class BodyPart
{
    [SerializeField] private string _name;
    [SerializeField] private float _givingBoodLevelPerSecond = 0f;
    [SerializeField] private float _filteringBloodPerSecond = 0f;
    [SerializeField] private float _bloodPumping = 0f;
    [SerializeField] private float _givingOxygen = 0f;
    [SerializeField] private float _givingOxygenStorage = 0f;

    public float GivingOxygen => _givingOxygen;
    public float GivingOxygenStorage => _givingOxygenStorage;
}
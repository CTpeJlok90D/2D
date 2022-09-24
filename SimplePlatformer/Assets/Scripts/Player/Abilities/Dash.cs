using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : Ability
{
    [SerializeField] private CharacterEffectList _ownerEffectList;
    [SerializeField] private AnimationCurve _speedCurve;

    private int _direction = 1;

    protected override void Execute()
    {
        _ownerEffectList.Add(new Effects.Dash(_speedCurve, _direction));
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        int currentDirection = (int)context.ReadValue<float>();
        if (currentDirection == 0)
        {
            return;
        }
        _direction = currentDirection;
    }
}

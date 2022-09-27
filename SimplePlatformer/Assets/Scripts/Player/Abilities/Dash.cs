using System.Collections;
using UnityEngine;

public class Dash : Ability
{
    [SerializeField] private CharacterController2D _characterController2D;
    [SerializeField] private AnimationCurve _speedCurve;

    private Coroutine _coroutine;
    private bool _dashing = false;


    public bool Dashing => _dashing;

    public void StopDash()
    {
        if (Dashing == false)
        {
            return;
        }
        StopCoroutine(_coroutine);
        _characterController2D.EnableControl();
        _dashing = false;
    }

    protected override void Execute()
    {
        if (_characterController2D.CanMove)
        {
            _coroutine = StartCoroutine(DashCorrutine());
        }
    }

    private IEnumerator DashCorrutine()
    {
        _dashing = true;
        _characterController2D.BlockControlOn(_speedCurve.keys[_speedCurve.keys.Length - 1].time);
        for (float i = 0; i < _speedCurve.keys[_speedCurve.keys.Length - 1].time; i += Time.fixedDeltaTime)
        {
            Vector2 kickDirection = new Vector2(_speedCurve.Evaluate(i) * _characterController2D.Direction, 0);
            _characterController2D.Kick(kickDirection);
            yield return null;
        }
        _dashing = false;
    }

    private void Awake()
    {
        _characterController2D.CrashIntoSomething.AddListener(StopDash);
    }
}
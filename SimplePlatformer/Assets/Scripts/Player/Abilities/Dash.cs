using UnityEngine;
using UnityEngine.InputSystem;
using Effects;

namespace Abilitys
{
    public class Dash : Ability
    {
        [SerializeField] private EffectList _characterEffectList;
        [SerializeField] private AnimationCurve _speedCurve;

        private Coroutine _coroutine;
        private bool _dashing = false;
        private int _direction = 0;
        private DashEffect _dash;

        public bool Dashing => _dashing;

        public void StopDash()
        {
            if (Dashing == false)
            {
                return;
            }
            _dash.Remove();
            _dashing = false;
        }

        public void ReadMove(InputAction.CallbackContext context)
        {
            int newValue = (int)context.ReadValue<float>(); 
            if (newValue == 0)
            {
                return;
            }
            _direction = (int)newValue;
        }
        
        protected override void Execute()
        {
            _dashing = true;
            _dash = new DashEffect(_speedCurve, _direction);
            _dash.OnDiturationEnd.AddListener(() => _dashing = false);
            _characterEffectList.Add(_dash);
        }
    }
}
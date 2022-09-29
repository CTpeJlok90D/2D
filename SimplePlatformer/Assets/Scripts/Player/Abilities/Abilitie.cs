using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Abilitys
{
    public abstract class Ability : MonoBehaviour
    {
        [SerializeField] private float _coolDown = 3f;
        [SerializeField] private float _prepairTime = 0f;
        [SerializeField] private UnityEvent _prepearStarted = new();
        [SerializeField] private UnityEvent _prepearCanceled = new();
        private float _currentCooldown = 0f;
        private float _currentPrepairingTime = 0f;
        private Coroutine _prepair;

        public bool Prepearing => _currentPrepairingTime > 0;
        protected float PrepairTime => _prepairTime;
        protected bool CanUse => _currentCooldown == 0f;
        protected float CurrentCooldown => _currentCooldown;
        protected UnityEvent PrepearStarted => _prepearStarted;
        protected UnityEvent PrepaerCanceled => _prepearCanceled;
        protected virtual bool ReduceCooldownCondiction => true;

        public void Use()
        {
            if (Prepearing)
            {
                return;   
            }
            _prepair = StartCoroutine(PrepairTimeCorutine());
        }
        
        private IEnumerator PrepairTimeCorutine()
        {
            _prepearStarted.Invoke();
            _currentPrepairingTime = _prepairTime;
            while (_currentPrepairingTime > 0)
            {
                _currentPrepairingTime = Mathf.Clamp(_currentPrepairingTime - Time.deltaTime, 0, Mathf.Infinity);
                yield return null;
            }
            if (CanUse)
            {
                Execute();
                _currentCooldown = _coolDown;
            }
        }

        protected abstract void Execute();

        public void StopPrepearing()
        {
            if (_prepairTime == 0)
            {
                return;
            }
            PrepaerCanceled.Invoke();
            StopCoroutine(_prepair);
            _currentPrepairingTime = 0;
        }

        private void ReduceCoolDown()
        {
            _currentCooldown = Mathf.Clamp(_currentCooldown-Time.deltaTime, 0, Mathf.Infinity);
        } 

        private void FixedUpdate()
        {
            if (ReduceCooldownCondiction)
            {
                ReduceCoolDown();
            }
        }
    }
}
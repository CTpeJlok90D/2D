using UnityEngine;
using Effects;

namespace Weapons 
{
    public class SimpleBullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _speed = 10;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private XPcontainer _container;

        public void Init(XPcontainer sender)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(true);
            _container = sender;
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.TryGetComponent(out EffectList effectList))
            {
                effectList.Add(new BaseDamage(_damage));
            }
            if (collision2D.gameObject.TryGetComponent(out XPgain xpGain))
            {
                xpGain.SetLastHittedPlayer(_container);
            }
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = transform.up * _speed;
        }
    }
}
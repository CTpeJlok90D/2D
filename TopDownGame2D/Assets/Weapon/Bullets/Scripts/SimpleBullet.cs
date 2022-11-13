using UnityEngine;
using Health;

namespace Weapons 
{
    public class SimpleBullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _speed = 10;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.TryGetComponent(out CharacterHealth health))
            {
                health.Current -= _damage;
            }
            if (collision2D.gameObject.TryGetComponent(out DamageImpact impact))
            {
                GameObject summonedObject = Instantiate(impact.HitSummonObject, transform.position, Quaternion.identity);
                summonedObject.transform.up = collision2D.contacts[0].normal;

            }
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = transform.up * _speed;
        }
    }
}
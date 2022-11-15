using Effects;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _strench;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.TryGetComponent(out EffectList effectList))
        {
            effectList.Add(new BaseDamage(_damage));
        }
        if (collision2D.gameObject.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            rigidbody2D.AddForce((rigidbody2D.position - (Vector2)transform.position) * _strench);
        }
    }
}

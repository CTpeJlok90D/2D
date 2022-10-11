using UnityEngine;
using Effects;
public class AttackMesh : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _stunTime = 1;
    [SerializeField] private Vector2 _punchVelocity = new Vector2(0, 0);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EffectList effectList))
        {
            effectList.Add(new Damage(_damage));
            effectList.Add(new Stun(_stunTime));
            effectList.Add(new Kick(new Vector2(transform.right.x, 1) * _punchVelocity));
        }   
    }
}

using UnityEngine;
using UnityEngine.Events;
using Effects;


public class Trap : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _stunTime = 1.5f;
    [SerializeField] private float _invulnerabilityTime = 2.0f;
    [SerializeField] private Vector2 _punchStrenth = new Vector2(1,1);
    [SerializeField] private UnityEvent _gotSomething;

    private void GiveDamage(EffectList effectList)
    {
        effectList.Add(new Damage(_damage));
        effectList.Add(new Stun(_stunTime));
        effectList.Add(new Invulnerability(_invulnerabilityTime));
        effectList.Add(new Kick(new Vector2(_punchStrenth.x * Mathf.Sign(effectList.transform.position.x - transform.position.x), _punchStrenth.y)));
        _gotSomething.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.TryGetComponent(out EffectList effectList))
        {
            GiveDamage(effectList);
        }
    }
}

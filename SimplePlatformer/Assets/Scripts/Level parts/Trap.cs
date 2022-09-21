using UnityEngine;
using UnityEngine.Events;
using Health;
using Player;
public class Trap : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _stunTime = 1.5f;
    [SerializeField] private Vector2 _punchStrenth = new Vector2(1,1);
    [SerializeField] private UnityEvent _gotSomething;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent(out EntityHealth health))
        {
            health.Damage(_damage);
        }
        if (other.TryGetComponent(out CharacterController2D character))
        {
            character.AddEffect(new Stun(_stunTime));
            character.Kick(new Vector2(
                _punchStrenth.x * Mathf.Sign(character.transform.position.x - transform.position.x),
                _punchStrenth.y));
            _gotSomething.Invoke();
        }
    }
}

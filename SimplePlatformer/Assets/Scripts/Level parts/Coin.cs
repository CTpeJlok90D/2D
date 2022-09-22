using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _amout = 1;
    [SerializeField] private float _dituration = 1f;
    [SerializeField] private Impact _impact = new();

    public int Amout => _amout;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cash cash))
        {
            cash.AddCoin(this);
        }
        if (collision.TryGetComponent(out CharacterEffectList effcts))
        {
            effcts.Add(new SimpleEffect(_dituration, _impact));
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _amout = 1;

    public int Amout => _amout;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cash cash))
        {
            cash.AddCoin(this);
            Destroy(this.gameObject);
        }
    }
}

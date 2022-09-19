using UnityEngine;
using UnityEngine.Events;

public class Cash : MonoBehaviour
{
    [SerializeField] private int _current = 0;
    [SerializeField] private UnityEvent _pickUpCoin;
    public int Current => _current;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _current += coin.Take();
            _pickUpCoin.Invoke();
        }
    }
}

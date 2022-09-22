using UnityEngine;
using UnityEngine.Events;

public class Cash : MonoBehaviour
{
    [SerializeField] private int _current = 0;
    [SerializeField] private UnityEvent _pickUpCoin;
    public int Current => _current;

    public void AddCoin(Coin coin)
    {
        _current += coin.Amout;
        _pickUpCoin.Invoke();
    }
}

using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _amout = 1;

    public int Take()
    {
        Destroy(gameObject);
        return _amout;
    }
}

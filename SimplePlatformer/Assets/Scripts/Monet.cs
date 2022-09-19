using UnityEngine;

public class Monet : MonoBehaviour
{
    [SerializeField] private int _amout = 1;

    public int Take()
    {
        Destroy(gameObject);
        return _amout;
    }
}

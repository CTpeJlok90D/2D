using UnityEngine;

public class Cash : MonoBehaviour
{
    [SerializeField] private int _current = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Monet monet))
        {
            _current += monet.Take();
        }
    }
}

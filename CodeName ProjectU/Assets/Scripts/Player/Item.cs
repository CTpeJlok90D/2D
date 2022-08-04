using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject _hint;
    [SerializeField] protected int _width;
    [SerializeField] protected int _height;

    private GameObject _instantiateHint;

    public void TakeItem()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Moving _))
        {
            _instantiateHint = Instantiate(_hint, this.transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Moving _))
        {
            Destroy(_instantiateHint);
        }
    }
}

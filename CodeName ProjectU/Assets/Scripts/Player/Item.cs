using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject _hint;
    [SerializeField] private UIItem _item;

    private GameObject _instantiateHint;

    public UIItem UIItem => _item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Moving _))
        {
            _instantiateHint = Instantiate(_hint, this.transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
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

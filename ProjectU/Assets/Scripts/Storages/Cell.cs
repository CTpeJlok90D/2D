using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Cell : MonoBehaviour
{
    [SerializeField] private Color _emptyColor;
    [SerializeField] private Color _fullColor;
    [SerializeField] private UIItem _item;

    private RawImage _image;

    public UIItem Item => _item;
    public void SetItem(UIItem item) 
    {
        _image = GetComponent<RawImage>();
        _item = item;
        if (_item == null)
        {
            _image.color = _emptyColor;
        }
        else
        {
            _image.color = _fullColor;
        }
    }
    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }
    private void OnDrawGizmos()
    {
        if (_item != null)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.white;
        }
        Gizmos.DrawSphere(transform.position + new Vector3(Container.CellSize / 2, Container.CellSize / 2), 5f);
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour
{
    [SerializeField] private Color _emptyColor;
    [SerializeField] private Color _fullColor;
    [SerializeField] private Sprite _fullSprite;
    [SerializeField] private Sprite _emptySprite;
    private UIItem _item;
    private UnityEvent _onItemChange = new();

    private Image _image;

    public UIItem UIItem => _item;
    public UnityEvent OnItemChange => _onItemChange;

    public void SetItem(UIItem item, bool InvokeIvent = true) 
    {
        _image = GetComponent<Image>();
        _item = item;
        if (InvokeIvent)
        { 
            _onItemChange.Invoke(); 
        }
        if (_item == null)
        {
            _image.color = _emptyColor;
            _image.sprite = _emptySprite;
        }
        else
        {
            _image.color = _fullColor;
            _image.sprite = _fullSprite;
        }
    }
    private void Awake()
    {
        _image = GetComponent<Image>();
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

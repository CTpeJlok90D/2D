using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RectTransform))]
public class PopUpMenu : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] private PopUpElement[] _elements;
    [SerializeField] private Vector2 _positionOffset;
    [SerializeField] private PopUpElementObject _popUpObjectPrefab;

    public PopUpMenu Init(Transform parent, PopUpElement[] elements)
    {
        transform.SetParent(parent);
        _elements = elements;
        foreach (PopUpElement element in _elements)
        {
            PopUpElementObject _instantiateObject = Instantiate(_popUpObjectPrefab, transform.position, Quaternion.identity).Init(element);
            _instantiateObject.transform.SetParent(transform);
        }
        return this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(gameObject);
    }

    private Vector2 GetQuarter(Vector2 vector)
    {
        return new Vector2(Mathf.Sign(vector.x - Screen.width / 2), Mathf.Sign(vector.y - Screen.height / 2));
    }

    private void OnValidate()
    {
        _positionOffset = new Vector2(Mathf.Abs(_positionOffset.x), Mathf.Abs(_positionOffset.y));
    }

    private void Awake()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        rectTransform.pivot += GetQuarter(mousePosition) * _positionOffset;
        rectTransform.position = mousePosition;
    }
}

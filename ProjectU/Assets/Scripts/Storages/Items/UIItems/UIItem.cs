using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ObjectWithDescription),typeof(Image),typeof(PopUpMenuFabric))]
public class UIItem : MonoBehaviour
{
    [HideInInspector] public Vector2Int CorrectCords;
    [SerializeField] private Item _item;
    
    private GroundItem _groundItem;
    private List<Vector2Int> _occupiedSpace;
    private bool _rotated = false;
    private RectTransform _rectTransform;
    private PopUpMenuFabric _popUpMenuFabric;
    private ObjectWithDescription _description;

    public GroundItem GroundItem => _groundItem;
    public int Height => _item.Height;
    public List<Vector2Int> OccupiedSpace => _occupiedSpace;
    public Item Item => _item;
    public RectTransform RectTransform => _rectTransform;
    public PopUpMenuFabric PopUpMenuFabric => _popUpMenuFabric;

    public UIItem Init(Item item, GroundItem groundItem = null)
    {
        _item = item;
        _groundItem = groundItem;
        _occupiedSpace = _item.OccupiedSpace;
        GetComponent<Image>().sprite = _item.Sprite;
        _rectTransform.sizeDelta = new Vector2(Container.CellSize * _item.Wight, Container.CellSize * _item.Height);
        _description.Init(_item);

        return this;
    }

    public void OpenPopUpMenu()
    {
        _popUpMenuFabric.Create(Item.Actions);
    }

    public void Rotate()
    {
        _rotated = !_rotated;
        _rectTransform.pivot = _rotated ? new Vector2(0, 1) : new Vector2(0, 0f);
        transform.Rotate(new Vector3(0, 0, _rotated ? 90 : -90));
        for (int i = 0; i < _occupiedSpace.Count; i++)
        {
            _occupiedSpace[i] = new Vector2Int(_occupiedSpace[i].y, _occupiedSpace[i].x);
        }
    }

    public List<Vector2Int> CorrectOccupiedSpace()
    {
        List<Vector2Int> result = new();
        foreach (Vector2Int vector in _occupiedSpace)
        {
            result.Add(vector + CorrectCords);
        }
        return result;
    }

    protected void ClearItem()
    {
        _item = null;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _popUpMenuFabric = GetComponent<PopUpMenuFabric>();
        _description = GetComponent<ObjectWithDescription>();

        _rectTransform.pivot = new Vector2(0, 0f);
    }
}
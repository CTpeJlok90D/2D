using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RectTransform))]
public abstract class Container : MonoBehaviour
{
    public const int CellSize = 20;

    [SerializeField] protected int _height;
    [SerializeField] protected int _wight;
    [SerializeField] protected GameObject _character;
    [SerializeField] private Cell _cell;
    [SerializeField] private Transform _selectedItemPlace;
    [SerializeField] private Transform _itemsPlace;
    [SerializeField] private UIItem _uiItemPrefab;

    static protected UIItem _selectedItem;
    private List<List<Cell>> _space = new List<List<Cell>>();
    private bool _mouseOnPanel = false;
    private Vector2Int _mouseCellOn;
    private Vector2 _mouseCanvasPosition;

    static public UIItem SelectedItem => _selectedItem;
    protected Vector2Int MouseCellOn => _mouseCellOn;
    protected bool MouseOnPanel => _mouseOnPanel;
    protected UIItem UIItemPrefub => _uiItemPrefab;

    public void MouseMove(InputAction.CallbackContext context)
    {
        UpdateMouseCellPosition(context);
        UpdateMouseOnPanel();
        if (_selectedItem != null)
        {
            SelectedItemFollowMouse();
        }
    }
    public virtual void MouseClick(InputAction.CallbackContext context)
    {
        if (context.canceled && _mouseOnPanel)
        {
            if (TrySelectItem(_mouseCellOn))
            {
                return;
            }
            if (_selectedItem != null && TryPutItem(_selectedItem, _mouseCellOn))
            {
                _selectedItem = null;
            }
        }
    }
    protected virtual UIItem GiveNewItem(Item item, Vector2Int cellCords)
    {
        UIItem uiItem = Instantiate(_uiItemPrefab, _itemsPlace.transform).Init(item);

        PutItem(uiItem, cellCords);
        return uiItem;
    }
    protected virtual bool TrySelectItem(Vector2Int cell)
    {
        if (CanSelectItemOnCell(cell))
        {
            SelectItem(cell);
            return true;
        }
        return false;
    }
    protected bool CanSelectItemOnCell(Vector2Int cell)
    {
        return _mouseOnPanel && _selectedItem == null && GetCellByVector(cell).Item != null;
    }
    protected virtual bool TryGiveItem(Item item, Vector2Int cellCords)
    {
        if (CanPlaceItHere(item, cellCords))
        {
            GiveNewItem(item, cellCords);
            return true;
        }
        return false;
    }
    protected virtual bool TryPutItem(UIItem item, Vector2Int cellCords)
    {
        if (CanPlaceItHere(item, cellCords))
        {
            PutItem(item, cellCords);
            return true;
        }
        return false;
    }
    protected virtual void Awake()
    {
        FillSpace();
    }
    protected virtual void FillSpace()
    {
        RemoveAllCells();
        for (int i = 0; i < _height; i++)
        {
            _space.Add(new List<Cell>());
            for (int j = 0; j < _wight; j++)
            {
                Cell cell = Instantiate(_cell, transform);
                _space[i].Add(cell);
            }
        }
    }
    protected Cell GetCellByVector(Vector2Int _vector)
    {
        return _space[_vector.y][_vector.x];
    }
    private void PutItem(UIItem item, Vector2Int cellCords)
    {
        item.CorectCords = cellCords;
        item.transform.SetParent(_itemsPlace);
        item.transform.localPosition = new Vector3(cellCords.x, cellCords.y) * CellSize;

        foreach (Vector2Int cord in item.OccupiedSpace)
        {
            GetCellByVector(cord + cellCords).SetItem(item);
        }
    }
    private void SelectItem(Vector2Int cell)
    {
        _selectedItem = GetCellByVector(cell).Item;
        _selectedItem.transform.SetParent(_selectedItemPlace.transform);
        SelectedItemFollowMouse();

        foreach (Vector2Int cord in _selectedItem.OccupiedSpace)
        {
            GetCellByVector(_selectedItem.CorectCords + cord).SetItem(null);
        }
    }
    private bool CanPlaceItHere(UIItem item, Vector2Int cellCords)
    {
        foreach (Vector2Int cord in item.OccupiedSpace)
        {
            if (ItCellOnSpace(cellCords + cord) == false || GetCellByVector(cellCords + cord).Item != null)
            {
                return false;
            }
        }
        return true;
    }
    private bool CanPlaceItHere(Item item, Vector2Int cellCords)
    {
        foreach (Vector2Int cord in item.OccupiedSpace)
        {
            if (ItCellOnSpace(cellCords + cord) == false || GetCellByVector(cellCords + cord).Item != null)
            {
                return false;
            }
        }
        return true;
    }
    private void RemoveAllCells()
    {
        foreach (List<Cell> listCell in _space)
        {
            foreach (Cell cell in listCell)
            {
                Destroy(cell.gameObject);
            }
        }
        _space.Clear();
    }
    private void SelectedItemFollowMouse()
    {
        _selectedItem.transform.position = _mouseCanvasPosition;
    }
    private bool ItCellOnSpace(Vector2Int cellCord)
    {
        return (cellCord.x < _wight && cellCord.x >= 0) && (cellCord.y < _height && cellCord.y >= 0);
    }
    private void UpdateMouseOnPanel()
    {
        if ((_mouseCellOn.x != -1 && _mouseCellOn.y != -1) != _mouseOnPanel)
        {
            _mouseOnPanel = _mouseCellOn.x != -1 && _mouseCellOn.y != -1;
        }
    }
    private void UpdateMouseCellPosition(InputAction.CallbackContext context)
    {
        _mouseCanvasPosition = context.ReadValue<Vector2>();
        Vector2 mousePosition = (_mouseCanvasPosition - new Vector2(transform.position.x, transform.position.y)) / CellSize;
        _mouseCellOn = new Vector2Int((int)mousePosition.x, (int)mousePosition.y);
        _mouseCellOn = ItCellOnSpace(_mouseCellOn) ? _mouseCellOn : new Vector2Int(-1, -1);
    }
    private void OnValidate()
    {
        GetComponent<RectTransform>().pivot = new Vector2(0, 0);
    }
}
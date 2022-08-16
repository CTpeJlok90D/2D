using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public abstract class Container : MonoBehaviour
{
    public const int CellSize = 20;

    [SerializeField] protected Vector2Int _size;
    [SerializeField] private Transform _selectedItemPlace;
    [SerializeField] private Transform _itemsPlace;
    [SerializeField] private ContainerSettings _settings;
    [SerializeField] private OneItemCellRootParametrs[] _oneItemCells;
    [Header("Style")]
    [SerializeField] private Color _backGround;
    [SerializeField] private Color _frameColor;
    [SerializeField] private int _frameThickness = 1;
    [SerializeField] private Image _image;

    static private UIItem _selectedItem;
    private List<UIItem> _items = new();
    private bool _mouseOnPanel = false;
    private Vector2Int _mouseCellOn;
    private Vector2 _mouseCanvasPosition;
    private List<OneItemCellRoot> _oneItemCellRoots = new();
    private UIItem _uiItemPrefab;
    private ImageDrawer _imageDrawer;

    static protected UIItem SelectedItem => _selectedItem;
    public Vector2Int Size => _size;
    protected Vector2Int MouseCellOn => _mouseCellOn;
    protected bool MouseOnPanel => _mouseOnPanel;
    protected UIItem UIItemPrefub => _uiItemPrefab;
    protected ContainerSettings Settings => _settings;

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
    protected void DropItem(UIItem item)
    {
        _items.Remove(item);
    }
    protected virtual UIItem GiveNewItem(Item item, Vector2Int cellCords)
    {
        UIItem uiItem = Instantiate(_uiItemPrefab, _itemsPlace.transform).Init(item);

        PutItem(uiItem, cellCords);
        return uiItem;
    }
    protected virtual bool TrySelectItem(Vector2Int cell)
    {
        if (_mouseOnPanel && CanSelectItemOnCell(cell))
        {
            SelectItem(cell);
            return true;
        }
        return false;
    }
    protected bool CanSelectItemOnCell(Vector2Int cell)
    {
        return _mouseOnPanel && _selectedItem == null && GetUIItemByVector(cell) != null;
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
    protected UIItem GetUIItemByVector(Vector2Int vector)
    {
        foreach (UIItem item in _items)
        {
            foreach (Vector2Int occupaceidCell in item.OccupiedSpace)
            {
                if (item.CorectCords + occupaceidCell == vector)
                {
                    return item;
                }
            }
        }
        return null;
    }
    protected void PutItem(UIItem item, Vector2Int cellCords)
    {
        item.CorectCords = cellCords;
        item.transform.SetParent(_itemsPlace);
        item.transform.localPosition = new Vector3(cellCords.x, cellCords.y) * CellSize;
        _items.Add(item);
    }
    private void SelectItem(Vector2Int cell)
    {
        _selectedItem = GetUIItemByVector(cell);
        _selectedItem.transform.SetParent(_selectedItemPlace.transform);
        SelectedItemFollowMouse();
    }
    private bool CanPlaceItHere(UIItem item, Vector2Int cellCords)
    {
        foreach (Vector2Int cord in item.OccupiedSpace)
        {
            if (ItCellOnSpace(cellCords + cord) == false || GetUIItemByVector(cellCords + cord) != null)
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
            if (ItCellOnSpace(cellCords + cord) == false || GetUIItemByVector(cellCords + cord) != null)
            {
                return false;
            }
        }
        return true;
    }
    private void SelectedItemFollowMouse()
    {
        _selectedItem.transform.position = _mouseCanvasPosition;
    }
    private bool ItCellOnSpace(Vector2Int cellCord)
    {
        return cellCord.x < _size.x && cellCord.x >= 0 && cellCord.y < _size.y && cellCord.y >= 0;
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
        Vector2 mousePosition = (_mouseCanvasPosition - (Vector2)transform.position) / CellSize;
        _mouseCellOn = new Vector2Int((int)mousePosition.x, (int)mousePosition.y);
        _mouseCellOn = ItCellOnSpace(_mouseCellOn) ? _mouseCellOn : new Vector2Int(-1, -1);
    }
    private void GenerateOneItemCells()
    {
        foreach (OneItemCellRootParametrs parametr in _oneItemCells)
        {
            List<Vector2Int> cells = new();
            for (int x = 0; x < parametr.Size.x; x++)
            {
                for (int y = 0; y < parametr.Size.y; y++)
                {
                    cells.Add(parametr.Position + new Vector2Int(x, y));
                }
            }
            _oneItemCellRoots.Add(new OneItemCellRoot(cells));
        }
    }
    private void DrawOneItemCells()
    {
        foreach (OneItemCellRootParametrs parametr in _oneItemCells)
        {
            _imageDrawer.DrawCell(parametr.Position * CellSize, (parametr.Position + parametr.Size) * CellSize, _frameThickness, _backGround, _frameColor);
        }
    }
    private void DrawGrid()
    {
        _imageDrawer.FillByColor(_backGround);
        _imageDrawer.DrawGrid(new Vector2Int(-1, -1), _size * CellSize, CellSize, _frameThickness, _frameColor);
        DrawOneItemCells();
    }
    private void Awake()
    {
        _uiItemPrefab = _settings.UIItem;
        if (_image == null)
        {
            _image = GetComponent<Image>();
        }
        RectTransform rectTransform = GetComponent<RectTransform>();
        _imageDrawer = new(_image, rectTransform);
        GenerateOneItemCells();
        DrawGrid();
    }
}
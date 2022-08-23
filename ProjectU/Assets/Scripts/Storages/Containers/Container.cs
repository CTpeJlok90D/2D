using System;
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
    [SerializeField] private ContainerSettings _settings;
    [SerializeField] private List<OneItemCellRootParametrs> _oneItemCells;

    static private UIItem _selectedUIItem;
    private List<UIItem> _uiItems = new();
    private List<List<Cell>> _cells = new();
    private bool _mouseOnPanel = false;
    private Vector2Int _mouseCellOn;
    private Vector2 _mouseCanvasPosition;
    private List<OneItemCellRoot> _oneItemCellRoots = new();
    private UIItem _uiItemPrefab;
    private ImageDrawer _imageDrawer;

    static protected UIItem SelectedUIItem => _selectedUIItem;
    public Vector2Int Size => _size;
    protected Vector2Int MouseCellOn => _mouseCellOn;
    protected bool MouseOnPanel => _mouseOnPanel;
    protected UIItem UIItemPrefub => _uiItemPrefab;
    protected ContainerSettings Settings => _settings;
    protected List<UIItem> UIItems => new List<UIItem>(_uiItems);

    public virtual void MouseClick(InputAction.CallbackContext context)
    {
        if (context.canceled == false)
        {
            return;
        }
        if (TrySelectItem(_mouseCellOn))
        {
            return;
        }
        TryPutSelectedItem(_mouseCellOn);
    }

    public void MouseMove(InputAction.CallbackContext context)
    {
        UpdateMouseCellPosition(context);
        UpdateMouseOnPanel();
        if (_selectedUIItem != null)
        {
            SelectedItemFollowMouse();
        }
    }

    protected UIItem GiveNewItem(Item item, Vector2Int cellCords)
    {
        UIItem uiItem = item.CreateUIItem();
        uiItem.transform.SetParent(transform);

        PutItem(uiItem, cellCords);
        return uiItem;
    }

    protected bool TrySelectItem(Vector2Int cell)
    {
        if (_mouseOnPanel && CanSelectItemOnCell(cell))
        {
            SelectItem(cell);
            return true;
        }
        return false;
    }

    protected bool TryGiveItem(Item item, Vector2Int cellCords)
    {
        if (CanPlaceItHere(item, cellCords))
        {
            GiveNewItem(item, cellCords);
            return true;
        }
        return false;
    }

    protected bool TryPutItem(UIItem item, Vector2Int cellCords)
    {
        if (CanPlaceItHere(item, cellCords))
        {
            PutItem(item, cellCords);
            return true;
        }
        return false;
    }

    protected bool TryPutSelectedItem(Vector2Int cellCords)
    {
        if (_selectedUIItem != null && TryPutItem(_selectedUIItem, cellCords))
        {
            _selectedUIItem = null;
            return true;
        }
        return false;
    }

    protected void PutSelectedItem(Vector2Int cellCords)
    {
        PutItem(_selectedUIItem, cellCords);
        _selectedUIItem = null;
    }

    protected void DrawGrid()
    {
        _imageDrawer.FillByColor(_settings.BackgroundColor);
        _imageDrawer.DrawGrid(new Vector2Int(-1, -1), _size * CellSize, CellSize, _settings.FrameThickness, _settings.FrameColor);
    }

    protected UIItem GetUIItemByVector(Vector2Int vector)
    {
        foreach (UIItem item in _uiItems)
        {
            foreach (Vector2Int occupaceidCell in item.OccupiedSpace)
            {
                if (item.CorrectCords + occupaceidCell == vector)
                {
                    return item;
                }
            }
        }
        return null;
    }

    protected Cell GetCellByVector(Vector2Int vector)
    {
        return _cells[vector.y][vector.x];
    }

    protected bool CanSelectItemOnCell(Vector2Int cell)
    {
        return _mouseOnPanel && _selectedUIItem == null && GetUIItemByVector(cell) != null;
    }

    protected void SetItemInCells(List<Vector2Int> listVector, UIItem item)
    {
        foreach(Vector2Int vector in listVector)
        {
            GetCellByVector(vector).SetItem(item);
        }
    }

    protected void PutItem(UIItem uiItem, Vector2Int cellCords)
    {
        uiItem.CorrectCords = cellCords;
        uiItem.transform.SetParent(transform);
        uiItem.transform.localPosition = new Vector3(cellCords.x, cellCords.y) * CellSize;
        _uiItems.Add(uiItem);
        SetItemInCells(uiItem.CorrectOccupiedSpace(), uiItem);
        DrawItemFrame(uiItem);
    }

    protected void SelectItem(Vector2Int cell)
    {
        SelectItem(GetUIItemByVector(cell));
    }

    protected void SelectItem(UIItem item)
    {
        _selectedUIItem = item;
        _selectedUIItem.transform.SetParent(_selectedItemPlace.transform);
        SelectedItemFollowMouse();
        RemoveItem(_selectedUIItem);
    }

    protected void RemoveItem(UIItem item)
    {
        RemoveItemFrame(item);
        SetItemInCells(item.CorrectOccupiedSpace(), null);
        _uiItems.Remove(item);
    }

    protected void Clear()
    {
        UIItems.ForEach((UIItem item) =>
        {
            RemoveItem(item);
            Destroy(item.gameObject);
        });
        _uiItems.Clear();
    }

    protected bool CanPlaceItHere(UIItem item, Vector2Int cellCords)
    {
        foreach (Vector2Int cord in item.OccupiedSpace)
        {
            if (HaveItCell(cellCords + cord) == false || GetCellByVector(cellCords + cord).Item != null)
            {
                return false;
            }
        }
        return true;
    }

    protected bool CanPlaceItHere(Item item, Vector2Int cellCords)
    {
        foreach (Vector2Int cord in item.OccupiedSpace)
        {
            if (HaveItCell(cellCords + cord) == false || GetCellByVector(cellCords + cord).Item != null)
            {
                return false;
            }
        }
        return true;
    }

    private void SelectedItemFollowMouse()
    {
        _selectedUIItem.transform.position = _mouseCanvasPosition;
    }

    private bool HaveItCell(Vector2Int cellCord)
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
        _mouseCellOn = HaveItCell(_mouseCellOn) ? _mouseCellOn : new Vector2Int(-1, -1);
    }

    private void GenerateOneItemCells()
    {
        foreach (OneItemCellRootParametrs parametr in _oneItemCells)
        {
            List<Cell> cells = new();
            for (int y = parametr.Position.y; y < parametr.Size.y + parametr.Position.y; y++)
            {
                for (int x = parametr.Position.x; x < parametr.Size.x + parametr.Position.x; x++)
                {
                    cells.Add(GetCellByVector(new Vector2Int(x,y)));
                }
            }
            _oneItemCellRoots.Add(new OneItemCellRoot(cells));
        }
    }

    private void DrawOneItemCells()
    {
        foreach (OneItemCellRootParametrs parametr in _oneItemCells)
        {
            _imageDrawer.DrawCell(parametr.Position * CellSize, (parametr.Position + parametr.Size) * CellSize, _settings.FrameThickness, _settings.BackgroundColor, _settings.FrameColor);
        }
    }

    private void CreateCells()
    {
        for (int y = 0; y < _size.y; y++)
        {
            _cells.Add(new List<Cell>());
            for (int x = 0; x < _size.x; x++)
            {
                _cells[y].Add(new Cell());
            }
        }
    }

    private void DrawItemFrame(UIItem uiItem)
    {
        Vector2Int itemOccupiedSpaceBegin = uiItem.CorrectCords * CellSize - Vector2Int.one;
        Vector2Int itemOccupiedSpaceEnd = (uiItem.OccupiedSpace[uiItem.OccupiedSpace.Count - 1] + uiItem.CorrectCords) * CellSize + Vector2Int.one * CellSize;

        _imageDrawer.DrawCell(itemOccupiedSpaceBegin, itemOccupiedSpaceEnd, _settings.FrameThickness, _settings.FilledColor, _settings.FrameColor);
        DrawOneItemCells();
    }

    private void RemoveItemFrame(UIItem uiItem)
    { 
        Vector2Int itemOccupiedSpaceBegin = uiItem.CorrectCords * CellSize - Vector2Int.one;
        Vector2Int itemOccupiedSpaceEnd = (uiItem.OccupiedSpace[uiItem.OccupiedSpace.Count - 1] + uiItem.CorrectCords) * CellSize + Vector2Int.one * CellSize;

        _imageDrawer.DrawSquare(itemOccupiedSpaceBegin, itemOccupiedSpaceEnd, _settings.BackgroundColor);
        _imageDrawer.DrawGrid(itemOccupiedSpaceBegin, itemOccupiedSpaceEnd, CellSize, _settings.FrameThickness, _settings.FrameColor);
        DrawOneItemCells();
    }

    private void UpdateTexture()
    {
        DrawGrid();
        DrawOneItemCells();
        foreach (UIItem uiItem in _uiItems)
        {
            DrawItemFrame(uiItem);
        }
    }

    private void Awake()
    {
        _uiItemPrefab = _settings.UIItem;
        Image image = GetComponent<Image>();
        RectTransform rectTransform = GetComponent<RectTransform>();
        _imageDrawer = new ImageDrawer(image, rectTransform);
        CreateCells();
        GenerateOneItemCells();
        UpdateTexture();
    }
}
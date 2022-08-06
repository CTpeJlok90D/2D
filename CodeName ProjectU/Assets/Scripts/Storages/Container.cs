using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RectTransform))]
public abstract class Container : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _wight;
    [SerializeField] private int _cellSize = 40;
    [SerializeField] private Cell _cell;
    [SerializeField] private Canvas _canvas;

    protected List<List<Cell>> _space = new List<List<Cell>>();
    private Vector2Int _mouseCellOn;
    private Vector2 _mouseCanvasPosition;
    private RectTransform _rectTransform;
    static private UIItem _selectedItem;

    private bool _mouseOnPanel => _mouseCellOn.x != -1 && _mouseCellOn.y != -1;

    public void MousePos(InputAction.CallbackContext context)
    {
        _mouseCanvasPosition = context.ReadValue<Vector2>();
        Vector2 mousePosition = (context.ReadValue<Vector2>() - new Vector2(_rectTransform.position.x, _rectTransform.position.y)) / _cellSize;
        _mouseCellOn = new Vector2Int((int)mousePosition.x, (int)mousePosition.y * -1);
        _mouseCellOn = ItCellOnSpace(_mouseCellOn) ? _mouseCellOn : new Vector2Int(-1,-1);
        if (_selectedItem != null)
        {
            SelectedItemFollowMouse();
        }
    }
    public void MouseClick(InputAction.CallbackContext context)
    {
        if (context.started && _mouseOnPanel)
        {
            if (_selectedItem == null && GetCellByVector(_mouseCellOn).Item != null)
            {
                _selectedItem = GetCellByVector(_mouseCellOn).Item;
                _selectedItem.transform.SetParent(_canvas.transform);
                SelectedItemFollowMouse();
                foreach (Vector2Int cord in _selectedItem.OccupiedSpace)
                {
                    if (ItCellOnSpace(cord + _selectedItem.CorectCords))
                    {
                        GetCellByVector(cord + _selectedItem.CorectCords).Item = null;
                    }
                }
                return;
            }
            if (_selectedItem != null && TryAddItem(_selectedItem, _mouseCellOn))
            {
                Destroy(_selectedItem.gameObject);
            }
        }
    }
    protected virtual bool TryAddItem(UIItem item, Vector2Int cellCords)
    {
        if (CanAddItHere(item, cellCords) == false)
        {
            return false;
        }
        AddItem(item, cellCords);
        return true;
    }
    protected virtual void AddItem(UIItem item, Vector2Int cellCords)
    {
        Vector2Int _lastCell = item.OccupiedSpace[item.OccupiedSpace.Count - 1];
        UIItem uiItem = Instantiate(item, GetCellByVector(_lastCell + cellCords).transform);
        uiItem.transform.localPosition = Vector2.zero;
        uiItem.CorectCords = _lastCell;

        foreach (Vector2Int cord in uiItem.OccupiedSpace)
        {
           GetCellByVector(cord + cellCords).Item = uiItem;
        }
    }
    protected virtual bool CanAddItHere(UIItem item, Vector2Int cellCords)
    {
        foreach (Vector2Int cord in item.OccupiedSpace)
        {
            if (ItCellOnSpace(cellCords + cord) == false || GetCellByVector(cellCords + cord).Item != null)
            {
                Debug.Log(cellCords + cord);
                return false;
            }
        }
        return true;
    }
    protected void FillSpace()
    {
        _space.Clear();
        for (int i = 0; i < _height; i++)
        {
            _space.Add(new List<Cell>());
            for (int j = 0; j < _wight; j++)
            {
                Cell cell = Instantiate(_cell, this.transform);
                cell.Init(new Vector2Int(j, i), this);
                _space[i].Add(cell);
            }
        }
    }
    protected virtual void Awake()
    {
        FillSpace();
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.pivot = new Vector2(0,1);
    }
    private Cell GetCellByVector(Vector2Int _vector)
    {
        return _space[_vector.y][_vector.x];
    }
    private bool ItCellOnSpace(Vector2Int cellCord)
    {
        return (cellCord.x < _wight && cellCord.x >= 0) && (cellCord.y < _height && cellCord.y >= 0);
    }
    private void SelectedItemFollowMouse()
    {
        _selectedItem.transform.position = _mouseCanvasPosition + _selectedItem.MouseFollowOffcet;
    }
}
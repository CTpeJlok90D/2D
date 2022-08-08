using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundedItemsPanel : Container
{
    private List<Item> _items = new();
    public void AddItemInBack(Item item)
    {
        _items.Add(item);
        UpdateItemsView();
    }
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        UpdateItemsView();
    }
    public void ReloadRequstSpace()
    {
        _height = 0;
        foreach (Item item in _items)
        {
            _height += item.UIItem.Height;
        }
    }
    public override void MouseClick(InputAction.CallbackContext context)
    {
        TrySelectItem(_mouseCellOn);
        if (context.canceled && _selectedItem != null && _mouseOnPanel)
        {
            _selectedItem.PickUp();
        }
        UpdateItemsView();
    }
    protected override void FillSpace()
    {
        base.FillSpace();
        int height = 0;
        for (int i = 0; i < _items.Count; i += 1)
        {
            UIItem uiItem = GiveNewItem(_items[i].UIItem, new Vector2Int(0, height));
            uiItem.SetWorldItemPTR(_items[i]);
            height += uiItem.Height;
        }
    }
    protected override void Awake()
    {
        base.Awake();
    }
    private void UpdateItemsView()
    {
        List<Item> newList = new();
        foreach (Item item in _items)
        {
            if (item != null)
            {
                newList.Add(item);
            }
        }
        _items = newList;
        ReloadRequstSpace();
        FillSpace();
    }
}

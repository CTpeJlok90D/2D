using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundedItemsPanel : Container
{
    private List<GroundItem> _groundItems = new();
    private List<UIItem> _uiItems = new();
    public void AddItem(GroundItem grounditem)
    {
        _groundItems.Add(grounditem);
        FillSpace();
    }
    public void RemoveItem(GroundItem grounditem)
    {
        _groundItems.Remove(grounditem);
        FillSpace();
    }
    public override void MouseClick(InputAction.CallbackContext context)
    {
        if (context.started && MouseOnPanel && _selectedItem == null)
        {
            UIItem item = GetCellByVector(MouseCellOn).Item;
            TrySelectItem(MouseCellOn);
            _uiItems.Remove(item);
            if (item != null)
            {
                item.GroundItem.PickUpBy();
            }
            FillSpace();
        }
    }
    protected override void FillSpace()
    {
        _height = 0;
        foreach (GroundItem groundItem in _groundItems)
        {
            _height += groundItem.Item.Height;
        }
        base.FillSpace();
        UpdateUIItemList();

    }
    private void UpdateUIItemList()
    {
        foreach (UIItem uiItem in _uiItems)
        {
            Destroy(uiItem.gameObject);
        }
        _uiItems.Clear();
        int height = 0;
        foreach (GroundItem groundItem in _groundItems)
        {
            UIItem goundUIItem = Instantiate(UIItemPrefub).Init(groundItem.Item, groundItem);
            PutItem(goundUIItem, new Vector2Int(0, height));
            _uiItems.Add(goundUIItem);
            height += groundItem.Item.Height;
        }
    }
}

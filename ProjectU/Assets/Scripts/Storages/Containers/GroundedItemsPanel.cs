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
        if (context.canceled && MouseOnPanel && SelectedItem == null)
        {
            UIItem item = GetUIItemByVector(MouseCellOn);
            TrySelectItem(MouseCellOn);
            _uiItems.Remove(item);
            if (item != null)
            {
                item.GroundItem.PickUp();
            }
            FillSpace();
        }
    }
    protected void FillSpace()
    {
        _size.y = 0;
        foreach (GroundItem groundItem in _groundItems)
        {
            _size.y += groundItem.Item.Height;
        }
        UpdateUIItemList();
    }
    private void UpdateUIItemList()
    {
        foreach (UIItem uiItem in _uiItems)
        {
            DropItem(uiItem);
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

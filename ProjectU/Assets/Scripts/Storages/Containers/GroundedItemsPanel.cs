using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundedItemsPanel : Container
{
    [SerializeField] private List<GroundItem> _groundItems = new();
    [SerializeField] private Transform _owner;

    public override void MouseClick(InputAction.CallbackContext context)
    {
        if (context.canceled == false)
        {
            return;
        }

        UpdateUIItemList();
        if (CanSelectItemOnCell(MouseCellOn))
        {
            UIItem item = GetUIItemByVector(MouseCellOn);
            PickUpItem(item.GroundItem);
            SelectItem(item);
            return;
        }
        if (MouseOnPanel && SelectedUIItem != null)
        {
            DropSelectedItem();
        }
    }

    public void AddItem(GroundItem grounditem)
    {
        _groundItems.Add(grounditem);
        UpdateUIItemList();
    }

    public void RemoveItem(GroundItem grounditem)
    {
        _groundItems.Remove(grounditem);
    }

    public void DropSelectedItem()
    {
        if (SelectedUIItem != null)
        {
            Instantiate(Settings.GroundItem, _owner.transform.position, new Quaternion()).Init(SelectedUIItem.Item);
            Destroy(SelectedUIItem.gameObject);
        }
    }

    private void PickUpItem(GroundItem item)
    {
        RemoveItem(item);
        Destroy(item.gameObject);
    }

    private void UpdateUIItemList()
    {
        Clear();

        int height = 0;
        foreach (GroundItem groundItem in _groundItems)
        {
            UIItem goundUIItem = groundItem.Item.CreateUIItem(groundItem);
            PutItem(goundUIItem, new Vector2Int(0, height));
            height += groundItem.Item.Height;
        }
    }

    private void OnEnable()
    {
        UpdateUIItemList();
    }

    private void Start()
    {
        DrawGrid();
    }
}

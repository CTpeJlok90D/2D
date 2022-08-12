using UnityEngine;
using UnityEngine.InputSystem;

public class GroundedItemsPanel : Container
{
    public void AddItemInBack(Item item)
    {

    }
    public void RemoveItem(Item item)
    {

    }
    public override void MouseClick(InputAction.CallbackContext context)
    {
        TrySelectItem(_mouseCellOn);
        if (context.canceled && _selectedItem != null && _mouseOnPanel)
        {

        }
    }
}

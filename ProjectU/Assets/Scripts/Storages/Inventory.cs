using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : Container
{
    [SerializeField] private UIItem[] _testItem;
    [SerializeField] private RectTransform trashPanel;

    public void RotateSelectedItem(InputAction.CallbackContext context)
    {
        if (context.started && _selectedItem != null)
        {
            _selectedItem.Rotate();
            SelectedItemFollowMouse();
        }
    }
    public void DropSelectedItem()
    {
        if (_selectedItem != null)
        {
            _selectedItem.Drop(_character.transform.position);
        }
    }
    private void Start()
    {
        for (int i = 0; i < _testItem.Length; i++)
        {
            TryAddItem(_testItem[i], new Vector2Int(0, i));
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : Container
{
    [SerializeField] private Item[] _startItems;

    public void RotateSelectedItem(InputAction.CallbackContext context)
    {
        if (context.started && SelectedUIItem != null)
        {
            SelectedUIItem.Rotate();
        }
    }

    private void Start()
    {
        int height = 0;
        for (int i = 0; i < _startItems.Length; i++)
        {
            TryGiveItem(_startItems[i], new Vector2Int(0, height));
            height += _startItems[i].Height;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceOpener : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Moving _moving;
    [SerializeField] private FollowerCursor _cursor;

    private bool _inventoryIsOpen = false;

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _moving.StopMoving();
            InvertInventory();
            _playerInput.SwitchCurrentActionMap(ActionMaps.UI);
        }
    }
    public void CloseInventory(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InvertInventory();
            _playerInput.SwitchCurrentActionMap(ActionMaps.Player);
        }
    }
    private void InvertInventory()
    {
        _inventory.SetActive(!_inventoryIsOpen);
        _cursor.Following = _inventoryIsOpen;
        Cursor.visible = !_inventoryIsOpen;
        _inventoryIsOpen = !_inventoryIsOpen;
    }
}

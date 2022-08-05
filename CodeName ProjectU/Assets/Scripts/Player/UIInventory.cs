using UnityEngine;
using UnityEngine.InputSystem;

public class UIInventory : Container
{
    private PlayerMove _input;
    private InputAction _interactInventory;
    private bool _inventoryIsOpen = false;

    protected override void Awake()
    {
        base.Awake();
        _input = new PlayerMove();
        _interactInventory = _input.Player.InteractInventory;
        _interactInventory.Enable();
    }

    public void OpenInventory()
    {
        SetInventoryActive(true);
    }
    public void CloseInventory()
    {
        SetInventoryActive(false);
    }
    public void InvertInventory()
    {
        SetInventoryActive(!_inventoryIsOpen);
    }
    public void Input(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InvertInventory();
        }
    }

    private void SetInventoryActive(bool state)
    {
        _backgroundPanel.SetActive(state);
        _inventoryIsOpen = state;
    }
}
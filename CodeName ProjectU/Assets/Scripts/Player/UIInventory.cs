using UnityEngine;
using UnityEngine.InputSystem;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private PlayerMove _input;
    private InputAction _interactInventory;
    private bool _inventoryIsOpen = false;

    private void Awake()
    {
        _input = new PlayerMove();
        _interactInventory = _input.Player.InteractInventory;
        _interactInventory.Enable();
    }

    public void OpenInventory()
    {
        _panel.SetActive(true);
        _inventoryIsOpen = true;
    }
    public void CloseInventory()
    {
        _panel.SetActive(false);
        _inventoryIsOpen = false;
    }

    private void Update()
    {
        if (_interactInventory.ReadValue<float>() == 1f)
        {
            if (_inventoryIsOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : Container
{
    [SerializeField] private GroundItem _groundItemPrefab;
    [SerializeField] private Transform _owner;
    [SerializeField] private Item[] _startItems;

    public void RotateSelectedItem(InputAction.CallbackContext context)
    {
        if (context.started && _selectedItem != null)
        {
            _selectedItem.Rotate();
        }
    }
    public void DropSelectedItem()
    {
        if (_selectedItem != null)
        {
            Instantiate(_groundItemPrefab, _owner.transform.position, new Quaternion()).Init(_selectedItem.Item);
            Destroy(_selectedItem.gameObject);
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

using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : Container
{
    [SerializeField] private Transform _owner;
    [SerializeField] private Item[] _startItems;

    public void RotateSelectedItem(InputAction.CallbackContext context)
    {
        if (context.started && SelectedItem != null)
        {
            SelectedItem.Rotate();
        }
    }
    public void DropSelectedItem()
    {
        if (SelectedItem != null)
        {
            Instantiate(Settings.GroundItem, _owner.transform.position, new Quaternion()).Init(SelectedItem.Item);
            DropItem(SelectedItem);
            Destroy(SelectedItem.gameObject);
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

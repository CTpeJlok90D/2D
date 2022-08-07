using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemScanner : MonoBehaviour
{
    [SerializeField] private GroundedItemsPanel _itemsPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            _itemsPanel.AddItemInBack(item);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            _itemsPanel.RemoveItem(item);
        }
    }
}

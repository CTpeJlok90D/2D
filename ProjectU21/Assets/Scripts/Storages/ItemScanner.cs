using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemScanner : MonoBehaviour
{
    [SerializeField] private GroundedItemsPanel _itemsPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out GroundItem item))
        {
            _itemsPanel.AddItem(item);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GroundItem item))
        {
            _itemsPanel.RemoveItem(item);
        }
    }
}

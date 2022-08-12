using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemScanner : MonoBehaviour
{
    [SerializeField] private GroundedItemsPanel _itemsPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}

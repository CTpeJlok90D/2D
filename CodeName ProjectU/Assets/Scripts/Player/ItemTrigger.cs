using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    [SerializeField] private GroundItemPanel _itemPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Item item))
        {
            _itemPanel.AddItem(item.UIItem);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}

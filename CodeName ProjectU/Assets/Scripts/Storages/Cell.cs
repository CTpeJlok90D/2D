using UnityEngine;

public class Cell : MonoBehaviour
{
    private UIItem _item;
    private Vector2Int _position = Vector2Int.zero;
    private Container _container;

    public void Init(Vector2Int position, Container container)
    {
        _position = position;
        _container = container;
    }
    public void AddItem(Item item)
    {
        _item = Instantiate(item.UIItem,this.transform);
    }
}

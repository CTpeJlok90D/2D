using UnityEngine;

public class Cell : MonoBehaviour
{
    public UIItem Item;
    [SerializeField] private Vector2Int _position = Vector2Int.zero;
    [SerializeField] private Container _container;

    public void Init(Vector2Int position, Container container)
    {
        _position = position;
        _container = container;
    }
}

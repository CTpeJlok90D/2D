using UnityEngine;

public class Cell : MonoBehaviour
{
    private Vector2Int _position = Vector2Int.zero;
    private Container _container;

    public void Init(Vector2Int position, Container container)
    {
        _position = position;
        _container = container;
    }
    [HideInInspector] public UIItem Item;

    private void OnDrawGizmos()
    {
        if (Item != null)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.white;
        }
        Gizmos.DrawSphere(transform.position, 15f);
    }
}

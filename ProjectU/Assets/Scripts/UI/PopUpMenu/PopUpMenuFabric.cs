using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PopUpMenuFabric : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PopUpMenu _popUpMenu;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 MousePosition = Mouse.current.position.ReadValue();

        PopUpMenu menu = Instantiate(_popUpMenu, MousePosition, Quaternion.identity);
        menu.transform.SetParent(transform.parent);
    }
}

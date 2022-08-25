using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpMenu : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] private List<PopUpElement> _elements;

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(this.gameObject);
    }
}

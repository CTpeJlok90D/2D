using UnityEngine;
using UnityEngine.EventSystems;

public class Decription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _descriptionFrame;

    private GameObject _descriptionFrameInstantiete;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _descriptionFrameInstantiete = Instantiate(_descriptionFrame, transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(_descriptionFrameInstantiete);
    }
}

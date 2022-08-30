using UnityEngine;
using UnityEngine.EventSystems;

internal class ObjectWithDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ItemDescriptionFrame _descriptionFrame;

    private GameObject _descriptionFrameInstantiete;
    private Item _item;

    public ObjectWithDescription Init(Item item)
    {
        _item = item;
        return this;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        RemoveDescription();
        if (Container.SelectedUIItem != this)
        {
            _descriptionFrameInstantiete = Instantiate(_descriptionFrame, transform.parent).Init(_item).gameObject;
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        RemoveDescription();
    }

    private void OnDisable()
    {
        RemoveDescription();
    }

    private void RemoveDescription()
    {
        if (_descriptionFrameInstantiete != null)
        {
            Destroy(_descriptionFrameInstantiete);
        }
    }
}
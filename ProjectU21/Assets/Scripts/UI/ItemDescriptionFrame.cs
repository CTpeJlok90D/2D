using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemDescriptionFrame : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public ItemDescriptionFrame Init(Item item)
    {
        _text.text = $"{item.Name}\n\n{item.Description}";
        transform.position = Mouse.current.position.ReadValue();
        return this;
    }
}
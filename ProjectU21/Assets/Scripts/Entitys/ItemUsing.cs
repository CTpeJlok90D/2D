using UnityEngine;
using UnityEngine.InputSystem;

public class ItemUsing : MonoBehaviour
{
    [SerializeField] private Hands _hands;

    public void Use(InputAction.CallbackContext context)
    {
        if (_hands.UsebleItem == null)
        {
            return;
        }
        _hands.UsebleItem.Use(context);
    }

    public void AlternativeUse(InputAction.CallbackContext context)
    {
        if (_hands.UsebleItem == null || _hands.UsebleItem is IAlternativeUsevleItem == false)
        {
            return;
        }
        ((IAlternativeUsevleItem)_hands.UsebleItem).AlternativeUse(context);
    }
}
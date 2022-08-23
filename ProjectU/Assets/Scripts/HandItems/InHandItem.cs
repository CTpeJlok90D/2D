using UnityEngine;
using UnityEngine.InputSystem;

public abstract class UsebleItem : MonoBehaviour
{
    public abstract void Use(InputAction.CallbackContext context);
}
public interface IAlternativeUsevleItem
{
    public abstract void AlternativeUse(InputAction.CallbackContext context);
}
public interface IReloadebleItem
{
    public void Reload();
}
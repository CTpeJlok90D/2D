using UnityEngine;
using UnityEngine.InputSystem;

public static class WorldMouse
{
    public static Vector2 Position => Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
}

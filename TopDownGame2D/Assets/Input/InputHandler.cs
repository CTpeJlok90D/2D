
using Unity.VisualScripting;

public static class InputHandler
{
    private static Input.PlayerInput _input;

    public static Input.PlayerInput Input => _input;

    static InputHandler()
    {
        _input = new Input.PlayerInput();
        _input.WorldMovement.Enable();
    }
}

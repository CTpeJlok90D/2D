public static class InputHandler
{
    private static Input.PlayerInput _input;

    public static Input.PlayerInput Singletone => _input;

    static InputHandler()
    {
        _input = new Input.PlayerInput();
        _input.WorldMovement.Enable();
    }
}

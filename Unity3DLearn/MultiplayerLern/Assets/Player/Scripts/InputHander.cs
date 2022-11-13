using UnityEngine;

public class InputHander : MonoBehaviour
{
    public static Input Singletone { get; private set; }
    private InputHander(){}

    private void Awake()
    {
        Singletone = new Input();
    }
}

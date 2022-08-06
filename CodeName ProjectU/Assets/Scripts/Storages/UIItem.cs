using UnityEngine;

public class UIItem : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _width;

    public int Height => _height;
    public int Width => _width;
}
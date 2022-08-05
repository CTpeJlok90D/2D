using UnityEngine;

public class UIItem : MonoBehaviour
{
    [SerializeField] protected int _width;
    [SerializeField] protected int _height;
//  [SerializeField] protected Sprite _sprite;
    protected Vector2 _position = new Vector2();

    public int Width => _width;
    public int Height => _height;

}

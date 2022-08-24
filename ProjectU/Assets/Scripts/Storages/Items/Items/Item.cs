using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _height = 1;
    [SerializeField] private int _wight = 1;
    [SerializeField] private Vector2 _localScale = Vector2.one;
    [SerializeField] private Vector2 _colliderScale = Vector2.one;
    [SerializeField] private UIItem UIItemPrefub;
    [SerializeField] private Sprite _sprite;
    private List<Vector2Int> _occupiedSpace = new();

    public string Name => _name;
    public string Description => _description;
    public int Height => _height;
    public int Wight => _wight;
    public Sprite Sprite => _sprite;
    public List<Vector2Int> OccupiedSpace => new(_occupiedSpace);
    public Vector2 LocalScale => _localScale;
    public Vector2 ColliderScale => _colliderScale;

    public virtual UIItem CreateUIItem(GroundItem groundItem = null)
    {
        return Instantiate(UIItemPrefub).Init(this, groundItem);
    }

    private void CalculateOccupiedSpace()
    {
        _occupiedSpace.Clear();
        for (int i = 0; i < _wight; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                _occupiedSpace.Add(new Vector2Int(i, j));
            }
        }
    }

    private void OnValidate()
    {
        _height = (int)Mathf.Clamp(_height, 1, Mathf.Infinity);
        _wight = (int)Mathf.Clamp(_wight, 1, Mathf.Infinity);
        CalculateOccupiedSpace();
    }
}
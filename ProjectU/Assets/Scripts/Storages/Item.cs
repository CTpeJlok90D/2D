using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _height = 1;
    [SerializeField] private int _wight = 1;
    private List<Vector2Int> _occupiedSpace = new();

    public int Height => _height;
    public int Wight => _wight;
    public Sprite Sprite => _sprite;
    public List<Vector2Int> OccupiedSpace => _occupiedSpace;

    private void OnValidate()
    {
        _height = (int)Mathf.Clamp(_height, 1, Mathf.Infinity);
        _wight = (int)Mathf.Clamp(_wight, 1, Mathf.Infinity);
        CalculateOccupiedSpace();
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
}
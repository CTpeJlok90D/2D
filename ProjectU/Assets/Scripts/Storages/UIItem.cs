using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : MonoBehaviour
{
    public Vector2Int CorectCords;
    [Header("Simple form")]
    [SerializeField] private bool _isRactangle = true;
    [SerializeField] private int _height = 1;
    [SerializeField] private int _wight = 1;
    [Space(10)]
    [SerializeField] private Vector2 _mouseFollowOffcet = Vector2.zero;
    [SerializeField] private List<Vector2Int> _occupiedSpace;

    public List<Vector2Int> OccupiedSpace => _occupiedSpace;
    public Vector2 MouseFollowOffcet => _mouseFollowOffcet;

    private void OnValidate()
    {
        if (_isRactangle)
        {
            _occupiedSpace.Clear();
            for (int i = 0; i < _wight; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _occupiedSpace.Add(new Vector2Int(i,j));
                }
            }
        }
    }
}
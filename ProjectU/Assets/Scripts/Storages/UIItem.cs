using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class UIItem : MonoBehaviour
{
    public Vector2Int CorectCords;
    [Header("Simple form")]
    [SerializeField] private bool _isRactangle = true;
    [SerializeField] private int _height = 1;
    [SerializeField] private int _wight = 1;
    [Space(10)]
    [SerializeField] private Item _worldItemPrefab;
    [Space(10)]
    [SerializeField] private float _cellSize = 40f;
    [SerializeField] private List<Vector2Int> _occupiedSpace;

    private bool _rotated = false;
    private RectTransform _rectTransform;
    private Vector2 _mouseFollowOffcet = Vector2.zero;
    private Item _worldItem = null;

    public int Height => _height;
    public int Wight => _wight;
    public List<Vector2Int> OccupiedSpace => _occupiedSpace;
    public Vector2 MouseFollowOffcet => _mouseFollowOffcet;

    public void SetWorldItemPTR(Item item)
    {
        _worldItem = item;
    }
    public void PickUp()
    {
        Destroy(_worldItem.gameObject);
    }
    public void Drop(Vector3 dropPos)
    {
        Instantiate(_worldItemPrefab, dropPos, Quaternion.identity);
        Destroy(gameObject);
    }
    public void Rotate()
    {
        _rotated = !_rotated;
        transform.Rotate(new Vector3(0,0, _rotated ? -90 : 90));
        _mouseFollowOffcet = new Vector2(Mathf.Abs(_mouseFollowOffcet.y), -_mouseFollowOffcet.x);
        for (int i = 0; i < _occupiedSpace.Count; i++)
        {
            _occupiedSpace[i] = new Vector2Int(_occupiedSpace[i].y, _occupiedSpace[i].x);
        }
    }
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mouseFollowOffcet = new Vector2(_rectTransform.sizeDelta.x - _cellSize/2, 0);
    }
    private void OnValidate()
    {
        if (_isRactangle && _occupiedSpace.Count != 0)
        {
            CalculateOccupiedSpace();
        }
        else
        {
            CalculateParametrs(); 
        }
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
    private void CalculateParametrs()
    {
        _height = 0;
        _wight = 0;
        foreach (Vector2Int var in _occupiedSpace)
        {
            if (_height < var.y)
            {
                _height = var.y;
            }
            if (_wight < var.x)
            {
                _wight = var.x;
            }
        }
    }
}
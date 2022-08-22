﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform),typeof(Image))]
public class UIItem : MonoBehaviour
{
    [HideInInspector] public Vector2Int CorrectCords;

    [SerializeField] private Item _item;
    [SerializeField] private GroundItem _groundItem;

    [SerializeField] private List<Vector2Int> _occupiedSpace;
    private bool _rotated = false;
    private RectTransform _rectTransform;
    
    public GroundItem GroundItem => _groundItem;
    public int Height => _item.Height;
    public List<Vector2Int> OccupiedSpace => _occupiedSpace;
    public Item Item => _item;
    public RectTransform RectTransform => _rectTransform;

    public UIItem Init(Item item, GroundItem groundItem = null)
    {
        _item = item;
        _occupiedSpace = _item.OccupiedSpace;
        GetComponent<Image>().sprite = _item.Sprite;
        _rectTransform.sizeDelta = new Vector2(Container.CellSize, Container.CellSize);
        _rectTransform.localScale = new Vector2(_item.Wight, _item.Height);
        _groundItem = groundItem;

        return this;
    }
    public void Rotate()
    {
        _rotated = !_rotated;
        _rectTransform.pivot = _rotated ? new Vector2(0, 1) : new Vector2(0, 0f);
        transform.Rotate(new Vector3(0, 0, _rotated ? 90 : -90));
        for (int i = 0; i < _occupiedSpace.Count; i++)
        {
            _occupiedSpace[i] = new Vector2Int(_occupiedSpace[i].y, _occupiedSpace[i].x);
        }
    }
    public List<Vector2Int> CorrectOccupiedSpace()
    {
        List<Vector2Int> result = new();
        foreach (Vector2Int vector in _occupiedSpace)
        {
            result.Add(vector + CorrectCords);
        }
        return result;
    }
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.pivot = new Vector2(0, 0f);
    }
    private void OnValidate()
    {
        _rectTransform = GetComponent<RectTransform>();
        if (_item != null)
        {
            Init(_item);
            return;
        }

    }
}
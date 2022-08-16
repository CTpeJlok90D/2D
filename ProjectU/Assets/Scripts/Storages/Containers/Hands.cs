using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : Container
{
    [SerializeField] private Vector2Int[] _handsPosition;
    [SerializeField] private Transform _hands;
    private List<GroundItem> _correctItems = new();

    private void Start()
    {
        foreach (Vector2Int hand in _handsPosition) 
        {
            //GetUIItemByVector(hand).OnItemChange.AddListener(UpdateHandsItem);
        }
    }
    private void UpdateHandsItem()
    {
        foreach (GroundItem item in _correctItems)
        {
            Destroy(item.gameObject);
        }
        _correctItems.Clear();

        //foreach (Vector2Int hand in _handsPosition)
        //{
        //    if (GetUIItemByVector(hand).UIItem != null)
        //    {
        //        GroundItem item = Instantiate(Settings.GroundItem, _hands).Init(GetUIItemByVector(hand).UIItem.Item);
        //        item.Equip();
        //        _correctItems.Add(item);
        //    }
        //}
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : Container
{
    [SerializeField] private Item _testItem;

    private void Start()
    {
        TryAddItem(_testItem.UIItem, Vector2Int.zero);
        TryAddItem(_testItem.UIItem, new Vector2Int(0,1));
    }
}

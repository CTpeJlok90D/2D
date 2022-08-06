using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : Container
{
    [SerializeField] private Item testItem;

    protected override void Awake()
    {
        base.Awake();
        _space[0][0].AddItem(testItem);
    }
}

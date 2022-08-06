using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundItemPanel : Container
{
    public override void AddItem(UIItem _item)
    {
        Cell cell = Instantiate(_cell, _backgroundPanel.transform);
        _cells[0].Add(cell);
        cell.AddItem(_item);
    }

    protected override void Awake()
    {
        _cells.Add(new List<Cell>());
    }
    
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class OneItemCellRoot
{
    private List<Cell> _cells;

    public OneItemCellRoot(List<Cell> cells)
    {
        _cells = cells;
        _cells.ForEach((cell) =>
        {
            cell.OnItemChange.AddListener(() => SetItemsToAll(cell.UIItem));
        });
    }

    private void SetItemsToAll(UIItem item)
    {
        _cells.ForEach((cell) =>
        {
            cell.SetItem(item, false);
        });
    }
}

[Serializable]
public class OneItemCellRootParametrs
{
    public Vector2Int Position;
    public Vector2Int Size;
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class OneItemCellRoot
{
    private List<Vector2Int> _cells;

    public OneItemCellRoot(List<Vector2Int> cells)
    {
        _cells = cells;
        _cells.ForEach((cell) =>
        {
            //cell.OnItemChange.AddListener(() => SetItemsToAll(cell.UIItem));
        });
    }

    private void SetItemsToAll(UIItem item)
    {
        _cells.ForEach((cell) =>
        {
            //cell.SetItem(item);
        });
    }
}

[Serializable]
public class OneItemCellRootParametrs
{
    public Vector2Int Position;
    public Vector2Int Size;
}
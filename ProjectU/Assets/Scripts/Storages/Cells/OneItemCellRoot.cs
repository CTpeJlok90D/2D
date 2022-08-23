using System;
using System.Collections.Generic;
using UnityEngine;

public class OneItemCellRoot
{
    private List<Cell> _cells;

    public OneItemCellRoot(List<Cell> cells)
    {
        _cells = cells;
        foreach (Cell cell in _cells)
        {
            cell.OnItemChange.AddListener(() => SetItemToAll(cell.Item));
        }
    }

    private void SetItemToAll(UIItem item)
    {
        foreach(Cell cell in _cells)
        {
            cell.SetItemWithoutInvoke(item);
        }
    }
}

[Serializable]
public class OneItemCellRootParametrs
{
    public Vector2Int Position;
    public Vector2Int Size;

    public OneItemCellRootParametrs(Vector2Int position, Vector2Int size)
    {
        Init(position, size);
    }
    public OneItemCellRootParametrs(int positionX, int positionY, int sizeX, int sizeY)
    {
        Init(new Vector2Int(positionX, positionY), new Vector2Int(sizeX, sizeY));
    }
    public OneItemCellRootParametrs(){}
    private void Init(Vector2Int position, Vector2Int size)
    {
        Position = position;
        Size = size;
    }
}
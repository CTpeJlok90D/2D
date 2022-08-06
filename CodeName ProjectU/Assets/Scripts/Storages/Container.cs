using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Container : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _wight;
    [SerializeField] private Cell _cell;

    protected List<List<Cell>> _space = new();

    protected virtual void Awake()
    {
        for (int i = 0; i < _height; i++)
        {
            _space.Add(new List<Cell>());
            for (int j = 0; j < _wight; j++)
            {
                Cell cell = Instantiate(_cell, this.transform);
                cell.Init(new Vector2Int(j,i), this);
                _space[i].Add(cell);
            }
        }
    }
}
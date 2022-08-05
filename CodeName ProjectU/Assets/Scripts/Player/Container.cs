using System.Collections.Generic;
using UnityEngine;

abstract public class Container : MonoBehaviour
{
    [SerializeField] protected int _width;
    [SerializeField] protected int _height;
    [SerializeField] protected Cell _cell;
    [SerializeField] protected GameObject _backgroundPanel;
    protected List<List<Cell>> _cells = new();
    
    public virtual void AddItem(UIItem _item)
    {

    }
    public void DropItem()
    {

    }

    protected virtual void Awake()
    {
        for (int i = 0; i < _height; i++)
        {
            _cells.Add(new List<Cell>());
            for (int j = 0; j < _width; j++)
            {
                _cells[i].Add(Instantiate(_cell, _backgroundPanel.transform));
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell { };
abstract public class Container : MonoBehaviour
{
    [SerializeField] protected int _width;
    [SerializeField] protected int _height;
    protected List<List<Cell>> _cells;

    public void TakeItem()
    {

    }
    public void DropItem()
    {

    }
}
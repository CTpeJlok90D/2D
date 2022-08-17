using UnityEngine;
using UnityEngine.Events;

public class Cell
{
    private UIItem _item;
    private UnityEvent _onItemChange = new();

    public UIItem Item => _item;
    public UnityEvent OnItemChange => _onItemChange;
    
    public void SetItem(UIItem item)
    {
        _item = item;
        _onItemChange.Invoke();
    }
    public void SetItemWithoutInvoke(UIItem item)
    {
        _item = item;
    }
}
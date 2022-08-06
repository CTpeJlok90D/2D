using UnityEngine;

public class Cell : MonoBehaviour
{
    private UIItem _item;
    
    public void AddItem(UIItem item)
    {
        _item = Instantiate(item, transform);
    }
    
}

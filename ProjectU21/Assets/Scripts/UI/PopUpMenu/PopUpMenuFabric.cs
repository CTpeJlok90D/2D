using UnityEngine;

public class PopUpMenuFabric : MonoBehaviour
{
    [SerializeField] private PopUpMenu PopUpMenu;

    public void Create(PopUpElement[] elements)
    {
        PopUpMenu insantiateObject = Instantiate(PopUpMenu, transform.position, Quaternion.identity).Init(transform.parent, elements);
    }
}

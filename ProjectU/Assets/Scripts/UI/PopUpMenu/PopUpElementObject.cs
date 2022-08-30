using TMPro;
using UnityEngine;

class PopUpElementObject : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public PopUpElementObject Init(PopUpElement element)
    {
        text.text = element.Caption;
        return this;
    }
}

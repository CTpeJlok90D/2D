using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private UIItem _uiItem;

    public UIItem UIItem => _uiItem;
}
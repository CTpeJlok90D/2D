using UnityEngine;
using AI;

internal class Item : MonoBehaviour
{
    private void Awake()
    {
        TakeItem.AddHaulItem(this);
    }
}
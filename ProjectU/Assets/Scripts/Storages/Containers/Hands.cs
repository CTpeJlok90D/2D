using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hands : Container
{
    [SerializeField] private Transform _hands;
    [SerializeField] private List<GameObject> _handsItem;

    public override void MouseClick(InputAction.CallbackContext context)
    {
        if (context.canceled == false)
        {
            return;
        }
        if (SelectedItem != null && SelectedItem.Item is HandsItem)
        {
            if (CanPlaceItHere(SelectedItem, MouseCellOn))
            {
                TakeInHands(SelectedItem);
                PutSelectedItem(MouseCellOn);
            }
            return;
        }
        if (CanSelectItemOnCell(MouseCellOn))
        {
            foreach (GameObject var in _handsItem.ToArray())
            {
                RemoveFromHands(var);
            }
            SelectItem(MouseCellOn);
        }
    }

    private void TakeInHands(UIItem uiItem)
    {
        if (uiItem.Item is HandsItem == false)
        {
            throw new Exception($"Can not be equpped -> {uiItem.name}");
        }
        HandsItem handsItem = (HandsItem)uiItem.Item;
        _handsItem.Add(Instantiate(handsItem.InHandsPrefab, _hands));
    }

    private void RemoveFromHands(GameObject item)
    {
        _handsItem.Remove(item);
        Destroy(item.gameObject);
    }
}

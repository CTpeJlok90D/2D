using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class Hands : Container
{
    [SerializeField] private Transform _hands;
    [SerializeField] private List<GameObject> _handsItems;

    public override void MouseClick(InputAction.CallbackContext context)
    {
        if (context.canceled == false)
        {
            return;
        }

        if (TryPutSelectedItem())
        {
            return;
        }

        TrySelectItemInCell(MouseCellOn);
    }

    private bool TryPutSelectedItem()
    {
        if (SelectedUIItem != null && SelectedUIItem.Item is HandsItem)
        {
            if (CanPlaceItHere(SelectedUIItem, MouseCellOn))
            {
                TakeInHands(SelectedUIItem);
                PutSelectedItem(MouseCellOn);
            }
            return true;
        }
        return false;
    }

    private bool TrySelectItemInCell(Vector2Int cellCords)
    {
        if (CanSelectItemOnCell(cellCords))
        {
            SelectItem(cellCords);
            return true;
        }
        return false;
    }

    private void TakeInHands(UIItem uiItem)
    {
        if (uiItem.Item is HandsItem == false)
        {
            throw new Exception($"Can not be equpped -> {uiItem.name}");
        }

        HandsItem handsItem = (HandsItem)uiItem.Item;
        _handsItems.Add(handsItem.CreateInHandsPrefab(_hands));
    }

    private void RemoveFromHands(GameObject item)
    {
        _handsItems.Remove(item);
        Destroy(item.gameObject);
    }
}

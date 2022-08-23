using System;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class Hands : Container
{
    [SerializeField] private Transform _hands;
    [SerializeField] private Scope _scope;

    private UsebleItem _handsItem;
    public UsebleItem UsebleItem => _handsItem;

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
        if (SelectedUIItem != null && SelectedUIItem is HandsUIItem)
        {
            if (CanPlaceItHere(SelectedUIItem, MouseCellOn))
            {
                TakeInHands((HandsUIItem)SelectedUIItem);
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
            Destroy(_handsItem.gameObject);
            SelectItem(cellCords);
            _scope.ResetAccusity();
            return true;
        }
        return false;
    }

    private void TakeInHands(HandsUIItem uiItem)
    {
        HandsItem handsItem = (HandsItem)uiItem.Item;
        UsebleItem InHandsItemGameObject = handsItem.CreateInHandsPrefab(_hands);
        uiItem.InHandsItemGameObject = InHandsItemGameObject;
        _handsItem = InHandsItemGameObject;

        if (InHandsItemGameObject is Weapon)
        {
            Weapon weapon = (Weapon)InHandsItemGameObject;
            weapon.Init(_scope);
            _scope.SetAccusity(weapon);
        }
            
    }
}

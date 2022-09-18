using UnityEngine;

[CreateAssetMenu(menuName = "HandsItem")]
class HandsItem : Item
{
    [SerializeField] private UsebleItem _inHandsPrefub;
    [SerializeField] private Vector2 _handOffset;

    public UsebleItem InHandsPrefab => _inHandsPrefub;

    public UsebleItem CreateInHandsPrefab(Transform parent = null)
    {
        UsebleItem result = Instantiate(_inHandsPrefub, parent);
        result.transform.localPosition = _handOffset;
        return result;
    }
}
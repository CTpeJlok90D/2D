using UnityEngine;

[CreateAssetMenu(menuName = "HandsItem")]
class HandsItem : Item
{
    [SerializeField] private GameObject _inHandsPrefub;

    public GameObject InHandsPrefab => _inHandsPrefub;
}
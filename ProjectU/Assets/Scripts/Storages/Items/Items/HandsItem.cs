using UnityEngine;

[CreateAssetMenu(menuName = "HandsItem")]
class HandsItem : Item
{
    [SerializeField] private GameObject _inHandsPrefub;
    [SerializeField] private Vector2 _handOffset;
    [SerializeField] private float[] _handAngles;

    public GameObject InHandsPrefab => _inHandsPrefub;
    public float[] HandAngles => _handAngles;

    public GameObject CreateInHandsPrefab(Transform parent = null)
    {
        GameObject result = Instantiate(_inHandsPrefub, parent);
        result.transform.localPosition = _handOffset;
        return result;
    }
}
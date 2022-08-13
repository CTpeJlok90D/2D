using UnityEngine;

[CreateAssetMenu(menuName = "Container settings")]
public class ContainerSettings : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private UIItem _uiItemPrefab;
    [SerializeField] private Cell _cell;

    public UIItem UIItemPrefab => _uiItemPrefab;
    public Cell Cell => _cell;
}
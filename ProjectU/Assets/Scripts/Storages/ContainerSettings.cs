using UnityEngine;

[CreateAssetMenu(menuName = "Container settings")]
public class ContainerSettings : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private UIItem _uiItem;
    [SerializeField] private Cell _cell;
    [SerializeField] private GroundItem _groundItem;

    public UIItem UIItem => _uiItem;
    public Cell Cell => _cell;
    public GroundItem GroundItem => _groundItem;
}
using UnityEngine;

[CreateAssetMenu(menuName = "Container settings")]
public class ContainerSettings : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private UIItem _uiItem;
    [SerializeField] private GroundItem _groundItem;

    public UIItem UIItem => _uiItem;
    public GroundItem GroundItem => _groundItem;
}
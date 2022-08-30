using UnityEngine;

[CreateAssetMenu(menuName = "Container settings")]
public class ContainerSettings : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private GroundItem _groundItem;
    [Header("Style")]
    [SerializeField] private Color _backGround;
    [SerializeField] private Color _frameColor;
    [SerializeField] private Color _filledColor;
    [SerializeField] private int _frameThickness = 1;

    public GroundItem GroundItem => _groundItem;
    public Color BackgroundColor => _backGround;
    public Color FrameColor => _frameColor;
    public Color FilledColor => _filledColor;
    public int FrameThickness => _frameThickness;
}
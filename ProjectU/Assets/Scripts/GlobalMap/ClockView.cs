using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClockView : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private Color nullColor;
    [SerializeField] private Color fullColor;
    [SerializeField] private AnimationCurve _colorCurve;
#if UNITY_EDITOR
    [Range(0, 1)][SerializeField] private float _time = 0.5f;
#endif
    [Space(10)]
    [SerializeField] private DateEngine _dateEngine;
    [SerializeField] private TimeType _timeType;

    private Image _image;
    
    private void ApplyValue(float value)
    {
        _image.fillAmount = value;
        _image.color = Color.Lerp(fullColor, nullColor, _colorCurve.Evaluate(value));
    }
    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = fullColor;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _image = GetComponent<Image>();
        ApplyValue(_time);
    }
#endif
}

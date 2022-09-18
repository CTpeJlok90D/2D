using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CameraMove : MonoBehaviour
{
    [Range(_minSensivity, _maxSensivity)]
    [Header("Move")]
    [SerializeField] private float _sensivity = 1;
    [SerializeField] private Vector2 _positivaCameraBorder;
    [SerializeField] private Vector2 _negativeCameraBorder;
    [SerializeField] private Vector2 _center = Vector2.zero;
#if UNITY_EDITOR
    [SerializeField] private Color _borderColor = Color.yellow;
    [SerializeField] private bool _drawBorder = true; 
#endif
    [Header("Camera")]
    [SerializeField] private float _maxOrthographicSize = 50;
    [SerializeField] private float _minOrthographicSize = 10;
    private Camera _camera;
    private const float _minSensivity = 0.1f;
    private const float _maxSensivity = 2f;

    private Vector2 _mouseDelta;
    private InputAction.CallbackContext _mouseClick;
    public void SetSensivity(float value)
    {
        _sensivity = Mathf.Clamp(value, _minSensivity, _maxSensivity);
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        _mouseClick = context;
    }
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
    }
    public void OnScroll(InputAction.CallbackContext context)
    {
        _camera.orthographicSize = Mathf.Clamp(context.ReadValue<float>() + _camera.orthographicSize, _minOrthographicSize, _maxOrthographicSize);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (_mouseClick.performed || _mouseClick.started)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + _mouseDelta.x * _sensivity, _negativeCameraBorder.x + _center.x, _positivaCameraBorder.x + _center.x),
                Mathf.Clamp(transform.position.y + _mouseDelta.y * _sensivity, _negativeCameraBorder.y + _center.y, _positivaCameraBorder.y + _center.y),
                transform.position.z
                );
        }
    }
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (_drawBorder == false)
        {
            return;
        }
        Gizmos.color = _borderColor;
        Gizmos.DrawLine(new Vector2(_negativeCameraBorder.x, _negativeCameraBorder.y) + _center, new Vector2(_positivaCameraBorder.x, _negativeCameraBorder.y) + _center);
        Gizmos.DrawLine(new Vector2(_positivaCameraBorder.x, _negativeCameraBorder.y) + _center, new Vector2(_positivaCameraBorder.x, _positivaCameraBorder.y) + _center);
        Gizmos.DrawLine(new Vector2(_positivaCameraBorder.x, _positivaCameraBorder.y) + _center, new Vector2(_negativeCameraBorder.x, _positivaCameraBorder.y) + _center);
        Gizmos.DrawLine(new Vector2(_negativeCameraBorder.x, _positivaCameraBorder.y) + _center, new Vector2(_negativeCameraBorder.x, _negativeCameraBorder.y) + _center);
    }
}
#endif
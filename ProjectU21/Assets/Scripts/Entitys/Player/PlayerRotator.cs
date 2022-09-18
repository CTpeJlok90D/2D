using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerRotator : SpriteRotator
{
    public Transform WorldCursor;

    private int _lookDirection = 1;
    private UnityEvent _rotate = new();
    private Transform _mainCursor;

    public int LookDirection => _lookDirection;

    private void UpdateLookDirection()
    {
        int correctDirection = (WorldCursor.position.x - transform.position.x) > 0 ? 1 : -1;
        if (_lookDirection != correctDirection)
        {
            _lookDirection = correctDirection;
            _rotate.Invoke();
        }
    }

    private void Update()
    {
        if (WorldCursor == null)
        {
            WorldCursor = _mainCursor;
        }
        LookAt(WorldCursor);
        UpdateLookDirection();
    }

    private void OnEnable()
    {
        _rotate.AddListener(Rotate);
    }

    private void OnDisable()
    {
        _rotate.RemoveListener(Rotate);
    }

    private void Awake()
    {
        _mainCursor = WorldCursor;
    }
}

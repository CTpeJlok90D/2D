using UnityEngine;

public class PlayerCopy : MonoBehaviour, IHaveDirection
{
    [SerializeField] private CharacterController2D _directionObject;
    [SerializeField] private SpriteRenderer _characterSpriteRenderer;
    [SerializeField] private Transform _targetObject;
    [SerializeField] protected float SmoothStrenth = 0.1f;
    [SerializeField] private Dash _dash;

    private SpriteRenderer _spriteRenderer;
    private int _lookDirection;

    public int Direction => _lookDirection;

    private void LateUpdate()
    {
        if (_dash.Dashing)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetObject.position, SmoothStrenth * Vector2.Distance(transform.position, _targetObject.position));
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _directionObject.transform.position, SmoothStrenth);
        }
        _lookDirection = _directionObject.Direction;
        _spriteRenderer.flipX = _characterSpriteRenderer.flipX;
        _spriteRenderer.sprite = _characterSpriteRenderer.sprite;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}

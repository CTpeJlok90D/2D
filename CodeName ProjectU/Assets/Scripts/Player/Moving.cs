using UnityEngine;

[RequireComponent(typeof(WayDirectrion))] 
public class Moving : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private SpriteRenderer _sprite;

    private WayDirectrion _way;
    private int _direction = 1;

    private void Awake()
    {
        _way = GetComponent<WayDirectrion>();
    }

    private void FixedUpdate()
    {
        Walk();
    }
    private void Walk()
    {
        float move = Input.GetAxis("Horizontal");
        if (move == 0) { return; }
        _direction = move > 0 ? 1 : -1;
        _sprite.flipX = _direction == -1;
        Vector2 direction = _way.GetDirection(_direction);
        transform.position += new Vector3(move * direction.x * _direction, move * direction.y * _direction, 0) * Time.fixedDeltaTime;

    }
}

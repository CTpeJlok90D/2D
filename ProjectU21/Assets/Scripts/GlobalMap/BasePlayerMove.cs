using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BasePlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _speedMultiply = 1f;
    private Vector2 _mousePosition = Vector2.zero;

    public bool Moving => transform.position != _target.position;
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            clickPosition = new Vector3(clickPosition.x, clickPosition.y, 0);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, clickPosition - transform.position, Vector2.Distance(transform.position, clickPosition));
            if (hit.collider != null)
            {
                _target.transform.position = hit.point;
            }
            else
            {
                _target.transform.position = clickPosition;
            }
        }
    }
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        if (Moving)
        {
            Move();
        }
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * _speedMultiply);
    }
}
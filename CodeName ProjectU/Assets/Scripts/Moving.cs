using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Moving : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;

    private Rigidbody2D _rigidBody;
    //private Sprite _sprite;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        //_sprite = GetComponentInChildren<Sprite>();
    }

    private void Update()
    {
        Walking();
    }
    private void Walking()
    {
        float move = Input.GetAxis("Horizontal");
        _rigidBody.position += new Vector2(move, 0);
    }
}

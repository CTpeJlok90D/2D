using UnityEngine;

public abstract class TopDownCharacter2D : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidBody;

    protected void Move(Vector2 direction)
    {
        _rigidBody.velocity = direction * _moveSpeed;
    }

    protected void LookAt(Vector2 position)
    {
        transform.up = position + (Vector2)transform.position;
    }
}

using UnityEngine.InputSystem;
using UnityEngine;

public class FollowerCursor : MonoBehaviour
{
    public bool Following = true;
    [Space(10)]
    [SerializeField] protected bool x = true;
    [SerializeField] protected bool y = true;
    [SerializeField] protected bool z = false;
    [SerializeField] protected float _accusity = 1;
    [SerializeField] protected Vector3 _offcet = Vector3.zero;
    protected virtual void Update()
    {
        if (Following)
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 _targetPosition = Vector3.MoveTowards(transform.position, target, _accusity);
            transform.position = new Vector3(
                x ? _targetPosition.x + _offcet.x : transform.position.x,
                y ? _targetPosition.y + _offcet.y : transform.position.y,
                z ? _targetPosition.z + _offcet.z : transform.position.z
                );
        }
    }
}
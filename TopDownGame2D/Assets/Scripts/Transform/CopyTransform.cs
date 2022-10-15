using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [SerializeField] protected bool x = true;
    [SerializeField] protected bool y = true;
    [SerializeField] protected bool z = false;

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
    private void Update()
    {
        transform.position = new Vector3(
            x ? _target.position.x : transform.position.x,
            y ? _target.position.y : transform.position.y,
            z ? _target.position.z : transform.position.z
            );
    }
}

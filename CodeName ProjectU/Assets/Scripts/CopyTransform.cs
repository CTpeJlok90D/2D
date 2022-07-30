using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool x = true;
    [SerializeField] private bool y = true;
    [SerializeField] private bool z = false;
    void Update()
    {
        transform.position = new Vector3(x ? target.position.x : transform.position.x, y ? target.position.y : transform.position.y, z ? target.position.z : transform.position.z);
    }
}

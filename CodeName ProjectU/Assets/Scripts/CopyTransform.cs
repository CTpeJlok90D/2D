using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}

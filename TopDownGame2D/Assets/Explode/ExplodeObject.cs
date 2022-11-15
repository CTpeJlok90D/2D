using UnityEngine;

public class ExplodeObject : MonoBehaviour
{
    [SerializeField] private Explode _explodePrefub;

    public void Explode()
    {
        Instantiate(_explodePrefub, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
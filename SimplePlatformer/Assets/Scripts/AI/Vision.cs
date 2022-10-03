using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;

    public GameObject[] Objects => _objects.ToArray();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _objects.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _objects.Remove(collision.gameObject);
    }
}

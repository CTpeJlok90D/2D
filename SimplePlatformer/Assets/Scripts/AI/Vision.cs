using AI.Memory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private Brain _brain;

    public GameObject[] Objects => _objects.ToArray();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AIreaction reaction))
        {
            _brain.AddFactor(reaction.Factor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _objects.Remove(collision.gameObject);
    }
}

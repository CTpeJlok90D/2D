using AI.Memory;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private List<AIreaction> _visionObjects;
    [SerializeField] private Brain _brain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AIreaction reaction))
        {
            _visionObjects.Add(reaction);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AIreaction reaction))
        {
            _visionObjects.Remove(reaction);
        }
    }

    private void Update()
    {
        foreach (AIreaction reaction in _visionObjects)
        {
            _brain.AddFactor(reaction.Factor);
        }
    }
}

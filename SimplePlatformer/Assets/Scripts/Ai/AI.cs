using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _visibleObjects;      
        
        public void AddVisibleObject(GameObject visibleObject)
        {
            if (_visibleObjects.Contains(visibleObject))
            {
                return;
            }
            _visibleObjects.Add(visibleObject);
        }
        public void RemoveVisibleObject(GameObject visibleObject)
        {
            _visibleObjects.Remove(visibleObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AI
{
    public class Pathfinder : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMap;

        private List<AIKnok> _knoks;

        private void OnDrawGizmos()
        {
            
        }
    }

}
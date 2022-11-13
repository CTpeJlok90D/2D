using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CopyTransform))]
    public class Legs : MonoBehaviour
    {
        [SerializeField] private TopDownCharacter2D _ownerCharacter;
        [SerializeField] private float _smoothStrench;

        private void Update()
        {
            transform.up = Vector3.MoveTowards(transform.up, _ownerCharacter.MoveDirection, 1 / _smoothStrench);
        }
    }
}

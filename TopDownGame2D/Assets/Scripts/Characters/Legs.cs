using UnityEditorInternal;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CopyTransform))]
    public class Legs : MonoBehaviour
    {
        [SerializeField] private TopDownCharacter2D _ownerCharacter;

        private void Update()
        {
            if (_ownerCharacter.MoveDirection != Vector2.zero)
            {
                transform.up = (_ownerCharacter.MoveDirection + (Vector2)transform.position) - (Vector2)transform.position;
            }
        }
    }
}
